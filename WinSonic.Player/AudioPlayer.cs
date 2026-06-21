using System.Diagnostics;
using NAudio.Wave;

namespace WinSonic.Player;

public class WaveAudioPlayer
{
    private readonly IWavePlayer _wavePlayer;
    private float _volume;
    private bool _playerVolumeControl;

    public WaveAudioPlayer(
        IWavePlayer wavePlayer,
        float volume,
        bool playerVolumeControl
    )
    {
        _wavePlayer = wavePlayer;
        _volume = volume;
        _playerVolumeControl = playerVolumeControl;
    }

    private IWaveProvider _nowPlaying;
    
    public void LoadStream(Stream stream)
    {
        // Stop if we're currently playing otherwise it stacks lmao
        if (_wavePlayer.PlaybackState == PlaybackState.Playing)
        {
            _wavePlayer.Stop();
        }

        var mediaFoundationStream = new StreamMediaFoundationReader(stream);
        Debug.WriteLine($"Using stream for media foundation, Format {mediaFoundationStream.WaveFormat}");

        if (!_playerVolumeControl)
        {
            var provider = GetVolumeAdjustedProviderForStream(mediaFoundationStream);
            LoadFromProvider(provider);
        }
        else
        {
            LoadFromProvider(mediaFoundationStream);
        }
    }
    
    private void LoadFromProvider(IWaveProvider provider)
    {
        _nowPlaying = provider;
        _wavePlayer.Init(provider);
    }

    private IWaveProvider GetVolumeAdjustedProviderForStream(WaveStream stream)
    {
        if (stream.WaveFormat.BitsPerSample != 16)
        {
            Console.WriteLine(
                " [## WARN ##] Using non-16 bit float stream, volume is not set as the provider doesn't support it and neither does the device!"
            );

            return stream;
        }
        else
        {
            var volumeProvider = new VolumeWaveProvider16(stream);
            volumeProvider.Volume = _volume;
            return volumeProvider;
        }
    }

    public void StartPlayback()
    {
        _wavePlayer.Play();
    }
}
