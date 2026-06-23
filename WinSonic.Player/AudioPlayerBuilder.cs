using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace WinSonic.Player;

public class AudioPlayerBuilder
{
    public const float DEFAULT_VOLUME = 0.25f;
    private bool _playerVolumeControl = true;

    public static AudioPlayerBuilder Default()
    {
        return new AudioPlayerBuilder().WithWasapi().WithVolume(DEFAULT_VOLUME);
    }

    public WaveAudioPlayer Build()
    {
        var player = new WaveAudioPlayer(_wavePlayer, _volume, _playerVolumeControl);
        
        if (_playerVolumeControl)
        {
            _wavePlayer.Volume = _volume;
        }
        return player;
    }

    private WasapiPlayer? _wavePlayer;
    private float _volume;

    public AudioPlayerBuilder WithWasapi(bool exclusiveMode = false)
    {
        var deviceEnumerator = new MMDeviceEnumerator();
        var outputDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

        var wasapiBuilder = new WasapiPlayerBuilder();

        wasapiBuilder.WithCategory(AudioStreamCategory.Media).WithDevice(outputDevice).WithSharedMode();

        if (exclusiveMode)
        {
            wasapiBuilder.WithExclusiveMode();
        }
        else
        {
            wasapiBuilder.WithSharedMode();
        }

        var wasapi = wasapiBuilder.Build();

        _wavePlayer = wasapi;

        Console.WriteLine($"Activating WASAPI audio output on device {outputDevice.FriendlyName}");
        return this;
    }

    public AudioPlayerBuilder WithVolume(float volume)
    {
        if (volume < 0.0f || volume > 1.0f)
        {
            throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0.0 and 1.0");
        }

        // Set the volume for the wave player
        _volume = volume;

        return this;
    }
}
