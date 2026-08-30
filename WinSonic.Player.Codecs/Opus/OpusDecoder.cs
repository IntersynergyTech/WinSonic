using SoundFlow.Enums;
using SoundFlow.Interfaces;
using SoundFlow.Structs;
using OpusSharp.Core.Extensions;
using System.Buffers.Binary;

namespace WinSonic.Player.Codecs.Opus;

public class OpusDecoder : ISoundDecoder
{
    private const int MaxOpusFrameSize = 5760;
    private static readonly byte[] OggPageHeaderSignature = "OggS"u8.ToArray();

    private readonly Stream _stream;
    private readonly OpusSharp.Core.OpusDecoder _internalDecoder;
    private readonly Queue<byte[]> _packetQueue = new();
    private readonly List<byte> _continuedPacket = new();
    private readonly float[] _frameBuffer;
    private readonly float[] _seekBuffer;
    private readonly int _length;

    private int _frameBufferOffset;
    private int _frameBufferCount;
    private bool _endOfStreamRaised;

    public OpusDecoder(Stream stream, AudioFormat format)
    {
        _stream = stream;

        _internalDecoder = new OpusSharp.Core.OpusDecoder(format.SampleRate, format.Channels);
        _frameBuffer = new float[MaxOpusFrameSize * format.Channels];
        _seekBuffer = new float[Math.Min(_frameBuffer.Length, 4096)];

        SampleFormat = SampleFormat.S16;
        Channels = format.Channels;
        SampleRate = format.SampleRate;
        _length = TryGetTrackLength();
    }

    public void Dispose()
    {
        if (IsDisposed)
        {
            return;
        }

        IsDisposed = true;
        _internalDecoder.Dispose();
        _stream.Dispose();
    }

    public bool Seek(int offset)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, this);
        if (!_stream.CanSeek || offset < 0)
        {
            return false;
        }

        _stream.Position = 0;
        _packetQueue.Clear();
        _continuedPacket.Clear();
        _frameBufferOffset = 0;
        _frameBufferCount = 0;
        _endOfStreamRaised = false;
        _internalDecoder.Reset();

        if (offset == 0)
        {
            return true;
        }

        var remaining = offset;
        while (remaining > 0)
        {
            var toRead = Math.Min(remaining, _seekBuffer.Length);
            var decoded = Decode(_seekBuffer.AsSpan(0, toRead), raiseEndOfStreamEvent: false);
            if (decoded == 0)
            {
                return false;
            }

            remaining -= decoded;
        }

        _endOfStreamRaised = false;
        return true;
    }

    public int Decode(Span<float> samples)
    {
        return Decode(samples, raiseEndOfStreamEvent: true);
    }

    public bool IsDisposed { get; private set; }
    public int Length => _length;
    public SampleFormat SampleFormat { get; }
    public int Channels { get; }
    public int SampleRate { get; }
    public event EventHandler<EventArgs>? EndOfStreamReached;

    private int Decode(Span<float> samples, bool raiseEndOfStreamEvent)
    {
        ObjectDisposedException.ThrowIf(IsDisposed, this);
        if (samples.IsEmpty)
        {
            return 0;
        }

        var written = 0;
        while (written < samples.Length)
        {
            if (_frameBufferCount > 0)
            {
                var copyCount = Math.Min(samples.Length - written, _frameBufferCount);
                _frameBuffer.AsSpan(_frameBufferOffset, copyCount).CopyTo(samples.Slice(written, copyCount));
                _frameBufferOffset += copyCount;
                _frameBufferCount -= copyCount;
                written += copyCount;
                continue;
            }

            if (!TryDecodeNextPacket())
            {
                if (raiseEndOfStreamEvent && !_endOfStreamRaised)
                {
                    _endOfStreamRaised = true;
                    EndOfStreamReached?.Invoke(this, EventArgs.Empty);
                }

                break;
            }
        }

        return written;
    }

    private bool TryDecodeNextPacket()
    {
        while (TryGetNextAudioPacket(out var packet))
        {
            var decodedFrameSize = _internalDecoder.Decode(packet, packet.Length, _frameBuffer, MaxOpusFrameSize, false);
            if (decodedFrameSize <= 0)
            {
                continue;
            }

            _frameBufferOffset = 0;
            _frameBufferCount = decodedFrameSize * Channels;
            return _frameBufferCount > 0;
        }

        return false;
    }

    private bool TryGetNextAudioPacket(out byte[] packet)
    {
        while (_packetQueue.Count == 0)
        {
            if (!TryReadNextPage())
            {
                packet = Array.Empty<byte>();
                return false;
            }
        }

        packet = _packetQueue.Dequeue();
        return true;
    }

    private bool TryReadNextPage()
    {
        var header = new byte[27];
        var bytesRead = ReadFully(header);
        if (bytesRead == 0)
        {
            return false;
        }

        if (bytesRead != header.Length || !header.AsSpan(0, 4).SequenceEqual(OggPageHeaderSignature))
        {
            throw new InvalidDataException("Invalid Ogg/Opus stream: missing Ogg page header.");
        }

        var segmentCount = header[26];
        var lacingTable = new byte[segmentCount];
        if (ReadFully(lacingTable) != lacingTable.Length)
        {
            throw new InvalidDataException("Invalid Ogg/Opus stream: incomplete lacing table.");
        }

        var payloadLength = 0;
        for (var i = 0; i < lacingTable.Length; i++)
        {
            payloadLength += lacingTable[i];
        }

        var pagePayload = new byte[payloadLength];
        if (ReadFully(pagePayload) != pagePayload.Length)
        {
            throw new InvalidDataException("Invalid Ogg/Opus stream: incomplete page payload.");
        }

        var payloadOffset = 0;
        for (var i = 0; i < lacingTable.Length; i++)
        {
            var segmentSize = lacingTable[i];
            if (segmentSize > 0)
            {
                _continuedPacket.AddRange(pagePayload.AsSpan(payloadOffset, segmentSize).ToArray());
            }

            payloadOffset += segmentSize;

            if (segmentSize == 255)
            {
                continue;
            }

            if (_continuedPacket.Count == 0)
            {
                continue;
            }

            var packet = _continuedPacket.ToArray();
            _continuedPacket.Clear();

            if (packet.AsSpan().StartsWith("OpusHead"u8) || packet.AsSpan().StartsWith("OpusTags"u8))
            {
                continue;
            }

            _packetQueue.Enqueue(packet);
        }

        return true;
    }

    private int ReadFully(byte[] destination)
    {
        var totalRead = 0;
        while (totalRead < destination.Length)
        {
            var read = _stream.Read(destination, totalRead, destination.Length - totalRead);
            if (read == 0)
            {
                break;
            }

            totalRead += read;
        }

        return totalRead;
    }

    private int TryGetTrackLength()
    {
        if (!_stream.CanSeek)
        {
            return 0;
        }

        var originalPosition = _stream.Position;
        _stream.Position = 0;

        try
        {
            var header = new byte[27];
            var continuedPacket = new List<byte>(512);
            long lastGranulePosition = -1;
            int preSkip = 0;
            var hasReadPreSkip = false;

            while (true)
            {
                var headerBytesRead = ReadFully(header);
                if (headerBytesRead == 0)
                {
                    break;
                }

                if (headerBytesRead != header.Length || !header.AsSpan(0, 4).SequenceEqual(OggPageHeaderSignature))
                {
                    throw new InvalidDataException("Invalid Ogg/Opus stream: missing Ogg page header.");
                }

                var segmentCount = header[26];
                var lacingTable = new byte[segmentCount];
                if (ReadFully(lacingTable) != lacingTable.Length)
                {
                    throw new InvalidDataException("Invalid Ogg/Opus stream: incomplete lacing table.");
                }

                var payloadLength = 0;
                for (var i = 0; i < lacingTable.Length; i++)
                {
                    payloadLength += lacingTable[i];
                }

                var pagePayload = new byte[payloadLength];
                if (ReadFully(pagePayload) != pagePayload.Length)
                {
                    throw new InvalidDataException("Invalid Ogg/Opus stream: incomplete page payload.");
                }

                var granulePosition = BinaryPrimitives.ReadInt64LittleEndian(header.AsSpan(6, 8));
                if (granulePosition >= 0)
                {
                    lastGranulePosition = granulePosition;
                }

                if (!hasReadPreSkip)
                {
                    var payloadOffset = 0;
                    for (var i = 0; i < lacingTable.Length; i++)
                    {
                        var segmentSize = lacingTable[i];
                        if (segmentSize > 0)
                        {
                            continuedPacket.AddRange(pagePayload.AsSpan(payloadOffset, segmentSize).ToArray());
                        }

                        payloadOffset += segmentSize;

                        if (segmentSize == 255)
                        {
                            continue;
                        }

                        if (continuedPacket.Count < 19)
                        {
                            continuedPacket.Clear();
                            continue;
                        }

                        var packet = continuedPacket.ToArray();
                        continuedPacket.Clear();
                        if (!packet.AsSpan().StartsWith("OpusHead"u8))
                        {
                            continue;
                        }

                        preSkip = BinaryPrimitives.ReadUInt16LittleEndian(packet.AsSpan(10, 2));
                        hasReadPreSkip = true;
                        break;
                    }
                }
            }

            if (lastGranulePosition <= 0)
            {
                return 0;
            }

            var pcmFramesAt48k = Math.Max(0L, lastGranulePosition - preSkip);
            var scaledFrames = SampleRate == 48000
                ? pcmFramesAt48k
                : (pcmFramesAt48k * SampleRate + 24000) / 48000;

            var channeledFrames = scaledFrames * Channels;

            return channeledFrames > int.MaxValue ? int.MaxValue : (int)channeledFrames;
        }
        finally
        {
            _stream.Position = originalPosition;
        }
    }
}
