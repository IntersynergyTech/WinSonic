using System.Diagnostics;
using NAudio.Wave;

namespace WinSonic.Player;

public class WaveAudioPlayer
{
    private readonly IWavePlayer _wavePlayer;
    private float _volume;
    
    public WaveAudioPlayer(IWavePlayer wavePlayer, float volume)
    {
        _wavePlayer = wavePlayer;
        _volume = volume;
    }

    public void LoadFile(string fileName)
    {
        var provider = new AudioFileReader(fileName);
        Debug.WriteLine($"Loaded audio file: {fileName}, Duration: {provider.TotalTime}, Format {provider.WaveFormat}");
        provider.Volume = _volume;
        _wavePlayer.Init(provider);
    }
    
    public void StartPlayback()
    {
        _wavePlayer.Play();
    }
}
