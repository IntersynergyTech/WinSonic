namespace WinSonic.Playback.Platform;

public interface ISystemMediaBroadcastService
{
    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public void BroadcastMediaInfo(string mediaTitle, string mediaArtist, string mediaAlbum, string? coverArtUrl = null);
    public void BroadcastVolume(float volume);
    public void SetCanGoNext(bool canGoNext);
    public void SetCanGoPrevious(bool canGoPrevious);
}

#if DEBUG
public class DummySystemMediaBroadcastService : ISystemMediaBroadcastService
{
    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public void BroadcastMediaInfo(string mediaTitle, string mediaArtist, string mediaAlbum, string? coverArtUrl = null)
    {
        // Implementation for broadcasting media info to the system
    }

    public void BroadcastVolume(float volume)
    {
        // Implementation for broadcasting volume to the system
    }

    public void SetCanGoNext(bool canGoNext)
    {
        // Implementation for setting whether the next action is available
    }

    public void SetCanGoPrevious(bool canGoPrevious)
    {
        // Implementation for setting whether the previous action is available
    }
}
#endif
