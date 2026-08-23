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
