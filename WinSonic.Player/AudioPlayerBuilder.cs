using NAudio.CoreAudioApi;
using NAudio.Wave;
using SoundFlow.Abstracts.Devices;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Structs;

namespace WinSonic.Player;

public class AudioPlayerBuilder
{
    public const float DEFAULT_VOLUME = 0.25f;
    private bool _playerVolumeControl = true;
    public static AudioFormat DEFAULT_FORMAT = AudioFormat.DvdHq;
    private AudioPlaybackDevice? _playbackDevice;

    public static AudioPlayerBuilder Default()
    {
        return new AudioPlayerBuilder().WithSoundFlow().WithVolume(DEFAULT_VOLUME);
    }

    public AudioPlayer Build()
    {
        var player = new AudioPlayer(_miniAudio, _volume, DEFAULT_FORMAT, _playbackDevice);

        return player;
    }

    private MiniAudioEngine? _miniAudio;
    private float _volume;

    public AudioPlayerBuilder WithSoundFlow(nint? audioDeviceId = null)
    {
        var miniAudio = new MiniAudioEngine();

        miniAudio.UpdateAudioDevicesInfo();

        var playbackDevice = miniAudio.PlaybackDevices.FirstOrDefault(d => d.Id == audioDeviceId);
        var format = DEFAULT_FORMAT;

        _playbackDevice = miniAudio.InitializePlaybackDevice(playbackDevice, format);

        _miniAudio = miniAudio;

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
