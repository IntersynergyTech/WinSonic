using WinSonic.Core.Enums;

namespace WinSonic.Player;

public interface ISoundFlowPlayer
{
    /// <summary>
    /// Set the output device. Use null to use the default device.
    /// </summary>
    /// <param name="deviceId"></param>
    public void SetOutputDevice(IntPtr? deviceId);
    
    public void LoadStream(Stream stream);
    
    public void Play();
    public void Pause();
    public void Stop();

    public PlaybackState PlaybackState { get; }
    
    public event EventHandler<PlaybackState> PlaybackStateChanged;
    public float Volume { get; set; }
    
}
