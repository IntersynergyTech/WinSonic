using NAudio.Wave;

namespace WinSonic.Player;

public class AudioPlayerBuilder
{
    public static float DEFAULT_VOLUME = 0.50f;

    public static AudioPlayerBuilder Default()
    {
        return new AudioPlayerBuilder().WithDirectSound().WithVolume(DEFAULT_VOLUME);
    }

    public WaveAudioPlayer Build()
    {
        var player = new WaveAudioPlayer(_wavePlayer, _volume);
        return player;
    }

    private IWavePlayer? _wavePlayer;
    private float _volume;

    public AudioPlayerBuilder WithDirectSound(Guid? deviceId = null)
    {
        var selectedOutputDevice = deviceId ?? DirectSoundOut.DSDEVID_DefaultPlayback;

        var directSound = new DirectSoundOut(selectedOutputDevice);

        _wavePlayer = directSound;

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
