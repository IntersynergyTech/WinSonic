using System.Diagnostics;
using SoundFlow.Abstracts.Devices;
using SoundFlow.Backends.MiniAudio;
using SoundFlow.Components;
using SoundFlow.Enums;
using SoundFlow.Providers;
using SoundFlow.Structs;
using SoundFlow.Structs.Events;

namespace WinSonic.Player;

public class AudioPlayer
{
    private readonly MiniAudioEngine _miniAudio;
    private SoundPlayer _player;
    private float _volume;
    private AudioFormat  _format;
    private AudioPlaybackDevice _outputDevice;
    private float _playbackBodgeSpeed;

    public AudioPlayer(
        MiniAudioEngine miniAudio,
        float volume,
        AudioFormat format,
        AudioPlaybackDevice outputDevice
    )
    {
        _miniAudio = miniAudio;
        _volume = volume;
        _miniAudio.DeviceStopped += MiniAudioOnDeviceStopped;
        _format = format;
        _outputDevice = outputDevice;
        _player = null;
        
        _outputDevice.Start();
    }

    private void MiniAudioOnDeviceStopped(object? sender, DeviceEventArgs e)
    {
        Console.WriteLine($"Playback stopped {e.Device.Format.Format} {e.Device.Format.SampleRate} {e.Device.Format.Channels}");
    }


    public void LoadStream(Stream stream)
    {
        // Stop if we're currently playing otherwise it stacks lmao
        if (_player?.State == PlaybackState.Playing)
        {
            _player.Stop();
            _outputDevice.MasterMixer.RemoveComponent(_player);
            _player.Dispose();
        }

        var provider = new StreamDataProvider(_miniAudio, stream);
        
        var formatFromProvider = new AudioFormat{Channels = provider.FormatInfo.ChannelCount, SampleRate = provider.SampleRate, Format = provider.SampleFormat};
        
        var player = new SoundPlayer(_miniAudio, formatFromProvider, provider);

        _playbackBodgeSpeed = 1; // ((float) _format.SampleRate) / formatFromProvider.SampleRate;
        player.PlaybackSpeed = _playbackBodgeSpeed;
        player.SetTimeStretchQuality(WsolaPerformancePreset.HighQuality);

        Debug.WriteLine($"Using stream for media foundation, Format {provider.FormatInfo.BitsPerSample} {provider.FormatInfo.SampleRate} {provider.FormatInfo.FormatIdentifier}");
        _outputDevice.Stop();
        _outputDevice.Start();
        _outputDevice.MasterMixer.AddComponent(player);

        _player = player;

    }

    public void StartPlayback()
    {
        _player.Play();
        _player.PlaybackSpeed = _playbackBodgeSpeed;
    }


    public void StopPlayback()
    {
        _player.Stop();
    }
}
