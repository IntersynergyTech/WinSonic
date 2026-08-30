using SoundFlow.Interfaces;
using SoundFlow.Enums;
using SoundFlow.Structs;
using WinSonic.Player.Codecs.Opus;
using System.Buffers.Binary;

namespace WinSonic.Player.Codecs;

public class WinSonicAdditionalCodecFactory : ICodecFactory
{
    private static readonly int[] SupportedOpusSampleRates = [8000, 12000, 16000, 24000, 48000];
    private static readonly byte[] OggPageHeaderSignature = "OggS"u8.ToArray();

    public ISoundDecoder? CreateDecoder(
        Stream stream,
        string formatId,
        AudioFormat format
    )
    {
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(formatId);

        if (!string.Equals(formatId, "opus", StringComparison.OrdinalIgnoreCase) && !string.Equals(formatId, "ogg", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        var decoderFormat = NormalizeFormat(format, hintFormat: null);

        if (!IsSupportedChannels(decoderFormat.Channels))
        {
            if (!stream.CanSeek)
            {
                return null;
            }

            var position = stream.Position;
            stream.Position = 0;
            var detected = TryReadOpusHead(stream, out var channels, out var sampleRate);
            stream.Position = position;

            if (!detected || !IsSupportedChannels(channels))
            {
                return null;
            }

            decoderFormat = CreateDecoderFormat(channels, sampleRate);
        }

        return new OpusDecoder(stream, decoderFormat);
    }

    public ISoundDecoder? TryCreateDecoder(
        Stream stream,
        out AudioFormat detectedFormat,
        AudioFormat? hintFormat = null
    )
    {
        ArgumentNullException.ThrowIfNull(stream);
        detectedFormat = default;

        if (!stream.CanSeek)
        {
            return null;
        }

        var originalPosition = stream.Position;
        stream.Position = 0;

        if (!TryReadOpusHead(stream, out var channels, out var sampleRate) || !IsSupportedChannels(channels))
        {
            stream.Position = originalPosition;
            return null;
        }

        var headerDetectedFormat = CreateDecoderFormat(channels, sampleRate);
        var decoderFormat = NormalizeFormat(headerDetectedFormat, hintFormat);

        detectedFormat = decoderFormat;
        stream.Position = 0;

        return new OpusDecoder(stream, decoderFormat);
    }

    public ISoundEncoder? CreateEncoder(
        Stream stream,
        string formatId,
        AudioFormat format
    )
    {
        throw new NotImplementedException();
    }

    public string FactoryId => "WinSonic.Player.Codecs.AdditionalCodecs";
    public IReadOnlyCollection<string> SupportedFormatIds { get; } = ["opus","ogg"];
    public int Priority { get; } = 10;

    private static AudioFormat NormalizeFormat(AudioFormat baseFormat, AudioFormat? hintFormat)
    {
        var source = hintFormat ?? baseFormat;
        var channels = IsSupportedChannels(source.Channels) ? source.Channels : baseFormat.Channels;
        if (!IsSupportedChannels(channels))
        {
            channels = 2;
        }

        var sampleRateCandidate = source.SampleRate > 0 ? source.SampleRate : baseFormat.SampleRate;
        return CreateDecoderFormat(channels, sampleRateCandidate);
    }

    private static AudioFormat CreateDecoderFormat(int channels, int sampleRate)
    {
        return new AudioFormat
        {
            Channels = channels,
            SampleRate = CoerceSampleRate(sampleRate),
            Format = SampleFormat.S16,
            Layout = AudioFormat.GetLayoutFromChannels(channels)
        };
    }

    private static int CoerceSampleRate(int sampleRate)
    {
        if (SupportedOpusSampleRates.Contains(sampleRate))
        {
            return sampleRate;
        }

        if (sampleRate <= 0)
        {
            return 48000;
        }

        var nearest = SupportedOpusSampleRates[0];
        var nearestDistance = Math.Abs(sampleRate - nearest);
        for (var i = 1; i < SupportedOpusSampleRates.Length; i++)
        {
            var candidate = SupportedOpusSampleRates[i];
            var distance = Math.Abs(sampleRate - candidate);
            if (distance < nearestDistance)
            {
                nearest = candidate;
                nearestDistance = distance;
            }
        }

        return nearest;
    }

    private static bool IsSupportedChannels(int channels)
    {
        return channels is 1 or 2;
    }

    private static bool TryReadOpusHead(Stream stream, out int channels, out int sampleRate)
    {
        channels = 0;
        sampleRate = 48000;

        var continuedPacket = new List<byte>(512);
        var pageHeader = new byte[27];

        for (var pagesRead = 0; pagesRead < 64; pagesRead++)
        {
            var headerRead = ReadFully(stream, pageHeader);
            if (headerRead == 0)
            {
                return false;
            }

            if (headerRead != pageHeader.Length || !pageHeader.AsSpan(0, 4).SequenceEqual(OggPageHeaderSignature))
            {
                return false;
            }

            var segmentCount = pageHeader[26];
            var lacingTable = new byte[segmentCount];
            if (ReadFully(stream, lacingTable) != lacingTable.Length)
            {
                return false;
            }

            var payloadLength = 0;
            for (var i = 0; i < lacingTable.Length; i++)
            {
                payloadLength += lacingTable[i];
            }

            var payload = new byte[payloadLength];
            if (ReadFully(stream, payload) != payload.Length)
            {
                return false;
            }

            var payloadOffset = 0;
            for (var i = 0; i < lacingTable.Length; i++)
            {
                var segmentSize = lacingTable[i];
                if (segmentSize > 0)
                {
                    continuedPacket.AddRange(payload.AsSpan(payloadOffset, segmentSize).ToArray());
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

                channels = packet[9];
                sampleRate = (int)BinaryPrimitives.ReadUInt32LittleEndian(packet.AsSpan(12, 4));
                return true;
            }
        }

        return false;
    }

    private static int ReadFully(Stream stream, byte[] buffer)
    {
        var totalRead = 0;
        while (totalRead < buffer.Length)
        {
            var read = stream.Read(buffer, totalRead, buffer.Length - totalRead);
            if (read == 0)
            {
                break;
            }

            totalRead += read;
        }

        return totalRead;
    }
}
