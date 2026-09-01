using System.Diagnostics;
using Microsoft.Extensions.Logging;
using SoundFlow.Abstracts.Devices;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Backends.MiniAudio.Devices;
using SoundFlow.Components;
using SoundFlow.Enums;
using SoundFlow.Metadata.Models;
using SoundFlow.Providers;
using SoundFlow.Structs;
using SoundFlow.Structs.Events;
using WinSonic.Core.Models;
using WinSonic.Player.Codecs;
using WinSonic.Player.ReplayGain;
using WinSonic.Service.Settings;
using PlaybackState = WinSonic.Core.Enums.PlaybackState;
using ReplayGainMode = WinSonic.Player.ReplayGain.ReplayGainMode;

namespace WinSonic.Player;

public class SoundFlowMultiPlayer : ISoundFlowPlayer
{
    private readonly ILogger<SoundFlowMultiPlayer> _logger;
    private readonly ISettingsService _settingsService;

    private MiniAudioEngine _engine;
    private Dictionary<AudioFormat, AudioPlaybackDevice> _playbackDevices = new ();
    private DeviceInfo _outputDevice;
    private DeviceInfo _defaultOutputDevice;
    private readonly ReplayGainProcessor _replayGainProcessor;
    private float VolumeLevel = 1f;
    private bool Muted = false;

    private MiniAudioDeviceConfig? _playbackDeviceConfig;
    private bool suppressPlaybackStateChangeEvents = false;

    private Song? _currentSong;
    private AudioFormat _currentFormat;
    private AudioPlaybackDevice? _currentActivePlaybackDevice;
    private SoundPlayer? _currentActivePlayer;
    private StreamDataProvider? _currentActiveProvider;
    private PlaybackState _playbackState;

    public SoundFlowMultiPlayer(ILoggerFactory loggerFactory, ISettingsService settingsService)
    {
        _settingsService = settingsService;
        _logger = loggerFactory.CreateLogger<SoundFlowMultiPlayer>();
        _replayGainProcessor = new (GetConfiguredReplayGain(), loggerFactory.CreateLogger<ReplayGainProcessor>());

        var engine = new MiniAudioEngine();
        _engine = engine;
        _engine.RegisterCodecFactory(new WinSonicAdditionalCodecFactory());

        engine.DeviceStopped += EngineOnDeviceStopped;
        engine.DeviceStarted += EngineOnDeviceStarted;

        UpdateSystemDefaultDevice();

        _replayGainProcessor.UpdateVolume(VolumeLevel);

        SelectOutputDevice(null);
    }

    private void EngineOnDeviceStarted(object? sender, DeviceEventArgs e)
    {
        _logger.LogDebug("{capability} device '{deviceName}' started.", e.Device.Capability, e.Device.Info?.Name);
    }

    private void EngineOnDeviceStopped(object? sender, DeviceEventArgs e)
    {
        _logger.LogDebug("{capability} device '{deviceName}' stopped.", e.Device.Capability, e.Device.Info?.Name);
    }

    private void UpdateSystemDefaultDevice()
    {
        _engine.UpdateAudioDevicesInfo();
        _defaultOutputDevice = _engine.PlaybackDevices.FirstOrDefault(d => d.IsDefault);
    }

    public void SetOutputDevice(IntPtr? deviceId)
    {
        if (_currentActivePlayer == null)
        {
            _logger.LogInformation("No active player, selecting output device without preserving state.");
            SelectOutputDevice(deviceId);
            return;
        }

        suppressPlaybackStateChangeEvents = true;
        var isPlaying = _currentActivePlayer.State == SoundFlow.Enums.PlaybackState.Playing;
        var currentTimestamp = _currentActivePlayer.Time;
        var currentVolume = _currentActivePlayer.Volume;
        var currentMute = _currentActivePlayer.Mute;

        UnloadPlayer(disposeProvider: false);
        SelectOutputDevice(deviceId);

        _currentActiveProvider.Seek(0);

        var playbackDevice = GetFormatPlaybackDevice(_currentFormat);

        _logger.LogInformation("Starting playback device for format [{format}]", _currentFormat.ToShortString());
        _currentActivePlaybackDevice = playbackDevice;
        _currentActivePlaybackDevice.Start();

        RegisterPlayer(currentVolume, currentMute, currentTimestamp);

        if (isPlaying)
        {
            _currentActivePlayer.Play();
        }
        _logger.LogInformation("Output device changed to {deviceName}. Playback state preserved: {isPlaying}, timestamp: {currentTimestamp}, volume: {currentVolume}, mute: {currentMute}",
            _outputDevice.Name,
            isPlaying,
            currentTimestamp,
            currentVolume, currentMute);

        suppressPlaybackStateChangeEvents = false;
    }

    private void RegisterPlayer(
        float volume,
        bool mute,
        float timestamp = 0
    )
    {
        _logger.LogInformation("Creating sound player for stream {title}", _currentActiveProvider.FormatInfo.Tags?.Title);
        var player = new SoundPlayer(_engine, _currentFormat, _currentActiveProvider);
        player.Volume = volume;
        player.Mute = mute;
        player.PlaybackEnded += PlayerOnPlaybackEnded;

        _currentActivePlaybackDevice.MasterMixer.AddComponent(player);

        _logger.LogInformation(
            "Created player for format [{format}] with volume {volume} (RG: {replayGainedVolume}). Ready to go",
            _currentFormat.ToShortString(),
            VolumeLevel,
            volume
        );

        player.Seek(timestamp);
        _currentActivePlayer = player;
    }

    public DeviceInfo[] GetAvailableDevices()
    {
        _engine.UpdateAudioDevicesInfo();

        var devices = _engine.PlaybackDevices;
        return devices;
    }

    private ReplayGainConfiguration GetConfiguredReplayGain()
    {
        var settings = _settingsService.GetSettingsAsync().GetAwaiter().GetResult();

        var mappedMode = settings.ReplayGainMode switch
        {
            Core.Models.ReplayGainMode.None => ReplayGainMode.None,
            Core.Models.ReplayGainMode.Track => ReplayGainMode.Track,
            Core.Models.ReplayGainMode.Album => ReplayGainMode.Album,
            Core.Models.ReplayGainMode.Auto => ReplayGainMode.Album, //todo: implement auto mode
        };

        var mappedClipPrevention = settings.ClippingPrevention switch
        {
            ReplayGainClippingPrevention.Off => ClippingPreventionMode.Off,
            ReplayGainClippingPrevention.ReduceGain => ClippingPreventionMode.Reduce,
            _ => ClippingPreventionMode.Off
        };

        var config = new ReplayGainConfiguration
        {
            Mode = mappedMode,
            ClippingPrevention = mappedClipPrevention,
            PreampAdjustment = ((float?) settings.Preamp) ?? 0,
            PreampEnabled = settings.Preamp != 0
        };

        return config;
    }

    private void SelectOutputDevice(IntPtr? deviceId)
    {
        var settingsDeviceName = _settingsService.GetSettingsAsync().GetAwaiter().GetResult().OutputDevice;

        if (deviceId != null)
        {
            _outputDevice = _engine.PlaybackDevices.FirstOrDefault(d => d.Id == deviceId);
        }
        else if (settingsDeviceName != null)
        {
            _outputDevice = _engine.PlaybackDevices.FirstOrDefault(d => d.Name == settingsDeviceName);

            if (_outputDevice == null)
            {
                _logger.LogWarning(
                    "Settings preffered device named {settingsDeviceName} not found. Falling back to default output device.",
                    settingsDeviceName
                );

                _outputDevice = _defaultOutputDevice;
            }
        }
        else
        {
            _outputDevice = _defaultOutputDevice;
        }

        DisposePlaybackDevices();

    }

    private void DisposePlaybackDevices()
    {
        foreach (var device in _playbackDevices.Values)
        {
            device.Dispose();
        }

        _playbackDevices.Clear();
    }

    private AudioPlaybackDevice GetFormatPlaybackDevice(AudioFormat format, bool forceReinit = false)
    {
        if (forceReinit || !_playbackDevices.ContainsKey(format))
        {
            InitFormatPlaybackDevice(format);
        }

        var existingPlayer = _playbackDevices[format];
        return existingPlayer;
    }

    private void InitFormatPlaybackDevice(AudioFormat format)
    {
        _logger.LogInformation(
            "Initializing playback device for format [{format}] on {outputDevice}",
            format.ToShortString(),
            _outputDevice.Name
        );

        AudioPlaybackDevice device;

        try
        {
            device = _engine.InitializePlaybackDevice(_outputDevice, format, _playbackDeviceConfig);
            _playbackDevices[format] = device;
        }
        catch (Exception e)
        {
            _logger.LogError(
                "Error initializing playback device for format [{format}] on {outputDevice}: {e}",
                format.ToShortString(),
                _outputDevice.Name,
                e.Message
            );

            try
            {
                _logger.LogWarning("Trying to reinit to system default output device... ");
                UpdateSystemDefaultDevice();

                _logger.LogWarning(
                    "Initializing platback for fallback  device... {defaultOutputDevice}",
                    _defaultOutputDevice.Name
                );

                device = _engine.InitializePlaybackDevice(_defaultOutputDevice, format, _playbackDeviceConfig);
                _playbackDevices[format] = device;
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception,
                    "Unable to initialize playback for any device. Error: {exception}",
                    exception.Message
                );

                Stop();
            }
        }
    }

    public void LoadStream(Stream stream, Song song)
    {
        UnloadPlayer();
        var player = GetPlayerForStream(stream, song);
        _currentActivePlayer = player;
        _currentSong = song;
    }

    private void UnloadPlayer(bool disposeProvider = true)
    {
        if (_currentActivePlayer == null) return;

        _currentActivePlayer.PlaybackEnded -= PlayerOnPlaybackEnded;

        _currentActivePlayer.Stop();
        _currentActivePlaybackDevice?.MasterMixer.RemoveComponent(_currentActivePlayer);
        if (disposeProvider)
        {
            // This doesn't just dispose the player, but it's stream provider too. Which is exceedingly unhelpful when we're trying to use it on another player. I'll get cleaned up later I'm sure :)
            _currentActivePlayer.Dispose();
        }
        _currentActivePlayer = null;
    }

    private SoundPlayer GetPlayerForStream(Stream stream, Song song)
    {
        _logger.LogInformation("Loading {streamType} stream for song {songTitle} by {songArtist}", stream.GetType().Name, song.Title, song.Artist);
        _currentActiveProvider = new StreamDataProvider(_engine, stream, new ReadOptions{DurationAccuracy = DurationAccuracy.FastEstimate, ReadTags = false});
        var providerFormat = _currentActiveProvider.FormatInfo!;

        var format = ParseFormatFrom(providerFormat);

        if (_currentFormat != format)
        {
            if (_currentActivePlaybackDevice != null)
            {
                _logger.LogInformation(
                    "Switching format from [{currentFormat}] to [{format}]",
                    _currentFormat.ToShortString(),
                    format.ToShortString()
                );

                if (_currentActivePlaybackDevice.IsRunning)
                {
                    _logger.LogInformation(
                        "Stopping current playback device for format [{currentFormat}] : currently isRunning {isRunning}",
                        _currentFormat.ToShortString(),
                        _currentActivePlaybackDevice.IsRunning
                    );

                    _currentActivePlaybackDevice.Stop();
                    _logger.LogInformation("Current playback device stopped");
                }
            }

            _logger.LogInformation("Getting playback device for format [{format}]", format.ToShortString());

            var playbackDevice = GetFormatPlaybackDevice(format);

            _logger.LogInformation("Starting playback device for format [{format}]", format.ToShortString());
            _currentActivePlaybackDevice = playbackDevice;
            _currentActivePlaybackDevice.Start();
        }

        var replayGainedVolume = _replayGainProcessor.UpdateTrackGain(
            song.ReplayGain.TrackGain,
            song.ReplayGain.AlbumGain
        );

        _currentFormat = format;

        RegisterPlayer(replayGainedVolume, Muted);
        return _currentActivePlayer;
    }

    private void PlayerOnPlaybackEnded(object? sender, EventArgs e)
    {
        // This event needs to get off this thread ASAP, as this thread is blocking the device. If we do anything with the device in this thread it might deadlock, so just whack it into async land and hope for the best
        Task.Run((() => { ChangePlaybackState(PlaybackState.Ended); }));
    }

    private AudioFormat ParseFormatFrom(SoundFormatInfo info)
    {
        var bitsPerSample = info.BitsPerSample switch
        {
            8 => SampleFormat.U8,
            16 => SampleFormat.S16,
            24 => SampleFormat.S24,
            32 => SampleFormat.S32,
            _ => SampleFormat.S16 // Default to 16-bit if unknown
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

        _logger.LogInformation("Parsed format from info: {newFormat}", newFormat.ToShortString());
        return newFormat;
    }

    public void Play()
    {
        _currentActivePlayer?.Play();
        ChangePlaybackState(PlaybackState.Playing);
    }

    public void Pause()
    {
        _currentActivePlayer?.Pause();
        ChangePlaybackState(PlaybackState.Paused);
    }

    public void Stop()
    {
        _currentActivePlayer?.Stop();
        ChangePlaybackState(PlaybackState.Stopped);
    }

    private void ChangePlaybackState(PlaybackState state)
    {
        if (!suppressPlaybackStateChangeEvents)
        {
            _logger.LogDebug("Changing playback state from {oldState} to {newState}", PlaybackState, state);
            PlaybackState = state;
            PlaybackStateChanged?.Invoke(this, state);
        }
    }

    public PlaybackState PlaybackState { get; private set; }

    public event EventHandler<PlaybackState>? PlaybackStateChanged;

    public float Volume
    {
        get => VolumeLevel;
        set
        {
            VolumeLevel = value;
            var rgVolume = _replayGainProcessor.UpdateVolume(value);
            _currentActivePlayer!.Volume = rgVolume;
        }
    }

    public bool IsMuted
    {
        get => Muted;
        set
        {
            Muted = value;
            _currentActivePlayer!.Mute = value;
        }
    }

    public Song? NowPlaying => _currentSong;
    public ReplayGainConfiguration ReplayGainConfiguration
    {
        get => _replayGainProcessor.GetConfiguration();
        set
        {
            _replayGainProcessor.UpdateConfiguration(value);
            _currentActivePlayer.Volume = _replayGainProcessor.GetVolume();
        }
    }

    public TimeSpan NowPlayingDuration => TimeSpan.FromSeconds(_currentActivePlayer?.Duration ?? 0);
    public TimeSpan CurrentPosition
    {
        get { return TimeSpan.FromSeconds(_currentActivePlayer?.Time ?? 0); }
        set { _currentActivePlayer?.Seek(value); }
    }
}
