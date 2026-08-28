using System;
using WinSonic.Playback.Platform;

namespace WinSonic.Gui.Xplat.Mac.Platform;

public class MacMediaBroadcastService : ISystemMediaBroadcastService
{
    // This service does abslutely nothing because I don't own a mac to test it on, but at least it shouldn't blow up on startup because the dep doesnt exist.
    
    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public void BroadcastMediaInfo(
        string mediaTitle,
        string mediaArtist,
        string mediaAlbum,
        string? coverArtUrl = null
    )
    {
    }

    public void BroadcastVolume(float volume)
    {
    }

    public void SetCanGoNext(bool canGoNext)
    {
    }

    public void SetCanGoPrevious(bool canGoPrevious)
    {
    }
}
