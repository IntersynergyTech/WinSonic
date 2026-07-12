using System.Diagnostics;
using SoundFlow.Abstracts.Devices;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Backends.MiniAudio.Devices;
using SoundFlow.Backends.MiniAudio.Enums;
using SoundFlow.Components;
using SoundFlow.Enums;
using SoundFlow.Metadata.Models;
using SoundFlow.Providers;
using SoundFlow.Structs;

namespace WinSonic.Player;

public class SoundFlowMultiPlayer : ISoundFlowPlayer
{
    private MiniAudioEngine _engine;
    private Dictionary<AudioFormat, SoundPlayer> _players = new ();
    private Dictionary<AudioFormat, AudioPlaybackDevice> _playbackDevices = new ();
    private DeviceInfo _outputDevice;
    private DeviceInfo _defaultOutputDevice;
    private float VolumeLevel = 1f;

    private MiniAudioDeviceConfig? _playbackDeviceConfig;

    private AudioFormat _currentFormat;
    private AudioPlaybackDevice? _currentActivePlaybackDevice;
    private SoundPlayer? _currentActivePlayer;

    public SoundFlowMultiPlayer(IntPtr? deviceId = null, bool exclusiveMode = false)
    {
        var engine = new MiniAudioEngine();
        engine.UpdateAudioDevicesInfo();
        _engine = engine;

        _defaultOutputDevice = engine.PlaybackDevices.FirstOrDefault(d => d.IsDefault);

        var shareMode = exclusiveMode ? ShareMode.Exclusive : ShareMode.Shared;

        _playbackDeviceConfig = new MiniAudioDeviceConfig()
        {
            Playback = new DeviceSubConfig { ShareMode = shareMode },
            
        };
        
        SelectOutputDevice(deviceId);
    }

    public void SetOutputDevice(IntPtr? deviceId)
    {
        SelectOutputDevice(deviceId);
    }

    private void SelectOutputDevice(IntPtr? deviceId)
    {
        if (deviceId == null)
        {
            _outputDevice = _defaultOutputDevice;
        }
        else
        {
            _outputDevice = _engine.PlaybackDevices.FirstOrDefault(d => d.Id == deviceId);
        }

        DisposePlaybackDevices();
    }

    private void DisposePlaybackDevices()
    {
        foreach (var device in _playbackDevices.Values)
        {
            device.Dispose();
        }

        _players.Clear();
    }

    private AudioPlaybackDevice GetFormatPlaybackDevice(AudioFormat format)
    {
        if (!_playbackDevices.ContainsKey(format))
        {
            InitFormatPlaybackDevice(format);
        }

        return _playbackDevices[format];
    }

    private void InitFormatPlaybackDevice(AudioFormat format)
    {
        Debug.WriteLine($"Initializing playback device for format: {format} on {_outputDevice.Name}");
        
        var device = _engine.InitializePlaybackDevice(_outputDevice, format, _playbackDeviceConfig);
        _playbackDevices[format] = device;
    }

    public void LoadStream(Stream stream)
    {
        UnloadPlayer();
        var player = GetPlayerForStream(stream);
        _currentActivePlayer = player;
    }

    private void UnloadPlayer()
    {
        if (_currentActivePlayer == null) return;

        _currentActivePlayer.Stop();
        _currentActivePlaybackDevice?.MasterMixer.RemoveComponent(_currentActivePlayer);
        _currentActivePlayer.Dispose();
        _currentActivePlayer = null;
    }

    private SoundPlayer GetPlayerForStream(Stream stream)
    {
        var provider = new StreamDataProvider(_engine, stream);
        var providerFormat = provider.FormatInfo!;

        var format = ParseFormatFrom(providerFormat);

        if (_currentFormat != format)
        {
            if (_currentActivePlaybackDevice != null)
            {
                Debug.WriteLine($"Switching format from {_currentFormat} to {format}");
                if (_currentActivePlaybackDevice.IsRunning) _currentActivePlaybackDevice.Stop();
            }

            var playbackDevice = GetFormatPlaybackDevice(format);

            Debug.WriteLine($"Starting playback device for format {format}");
            _currentActivePlaybackDevice = playbackDevice;
            _currentActivePlaybackDevice.Start();
        }

        _currentFormat = format;
        var player = new SoundPlayer(_engine, format, provider);
        player.Volume = VolumeLevel;
        _currentActivePlaybackDevice.MasterMixer.AddComponent(player);
        Debug.WriteLine($"Created player for format {format} with volume {VolumeLevel}. Ready to go");
        return player;
    }

    private AudioFormat ParseFormatFrom(SoundFormatInfo info)
    {
        Debug.WriteLine($"Parsing format from info: {info.FormatIdentifier}");

        var bitsPerSample = info.BitsPerSample switch
        {
            8 => SampleFormat.U8,
            16 => SampleFormat.S16,
            24 => SampleFormat.S24,
            32 => SampleFormat.S32,
            _ => throw new NotSupportedException($"Unsupported bits per sample: {info.BitsPerSample}")
        };

        var channelLayout = info.ChannelCount switch
        {
            1 => ChannelLayout.Mono,
            2 => ChannelLayout.Stereo,
            4 => ChannelLayout.Quad,
            6 => ChannelLayout.Surround51,
            8 => ChannelLayout.Surround71,
            _ => throw new NotSupportedException($"Unsupported channel count: {info.ChannelCount}")
        };

        var newFormat = new AudioFormat
        {
            Channels = info.ChannelCount,
            Format = bitsPerSample,
            SampleRate = info.SampleRate,
            Layout = channelLayout
        };

        return newFormat;
    }

    public void Play()
    {
        _currentActivePlayer?.Play();
    }

    public void Pause()
    {
        _currentActivePlayer?.Pause();
    }

    public void Stop()
    {
        _currentActivePlayer?.Stop();
    }

    public PlaybackState PlaybackState => _currentActivePlayer?.State ?? PlaybackState.Stopped;
    public float Volume
    {
        get => VolumeLevel;
        set
        {
            VolumeLevel = value;
            _currentActivePlayer.Volume = value;
        }
    }
}
