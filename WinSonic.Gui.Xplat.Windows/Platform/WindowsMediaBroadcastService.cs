using System;
using Microsoft.Extensions.Logging;
using Windows.Media;
using Windows.Media.Playback;
using WinSonic.Playback.Platform;

namespace WinSonic.Gui.Xplat.Windows.Platform;

public class WindowsMediaBroadcastService : ISystemMediaBroadcastService
{
    private readonly ILogger<WindowsMediaBroadcastService> _logger;
    private readonly MediaPlayer? _mediaPlayer;
    private readonly SystemMediaTransportControls? _smtc;
    private readonly object _gate = new();

    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public WindowsMediaBroadcastService(ILogger<WindowsMediaBroadcastService> logger)
    {
        _logger = logger;

        try
        {
            _mediaPlayer = new MediaPlayer();
            _smtc = _mediaPlayer.SystemMediaTransportControls;

            _smtc.IsEnabled = true;
            _smtc.IsPlayEnabled = true;
            _smtc.IsPauseEnabled = true;
            _smtc.IsNextEnabled = false;
            _smtc.IsPreviousEnabled = false;

            _smtc.ButtonPressed += OnButtonPressed;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to initialize Windows SystemMediaTransportControls.");
        }
    }

    public void BroadcastMediaInfo(
        string mediaTitle,
        string mediaArtist,
        string mediaAlbum,
        string? coverArtUrl = null
    )
    {
        if (_smtc == null)
        {
            _logger.LogWarning("Unable to broadcast media info because SystemMediaTransportControls is unavailable.");
            return;
        }

        try
        {
            var updater = _smtc.DisplayUpdater;
            updater.Type = MediaPlaybackType.Music;
            updater.MusicProperties.Title = mediaTitle;
            updater.MusicProperties.Artist = mediaArtist;
            updater.MusicProperties.AlbumTitle = mediaAlbum;

            // Placeholder support: cover art intentionally omitted when null.
            updater.Thumbnail = null;

            updater.Update();
            _smtc.PlaybackStatus = string.IsNullOrWhiteSpace(mediaTitle)
                ? MediaPlaybackStatus.Stopped
                : MediaPlaybackStatus.Playing;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to broadcast media info to SystemMediaTransportControls.");
        }
    }

    public void BroadcastVolume(float volume)
    {
        if (_mediaPlayer == null)
        {
            _logger.LogWarning("Unable to broadcast volume because SystemMediaTransportControls is unavailable.");
            return;
        }

        try
        {
            var clamped = Math.Clamp(volume, 0f, 1f);
            _mediaPlayer.Volume = clamped;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to broadcast volume to SystemMediaTransportControls.");
        }
    }

    public void SetCanGoNext(bool canGoNext)
    {
        if (_smtc == null)
        {
            _logger.LogWarning("Unable to set CanGoNext because SystemMediaTransportControls is unavailable.");
            return;
        }

        try
        {
            lock (_gate)
            {
                _smtc.IsNextEnabled = canGoNext;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to set CanGoNext on SystemMediaTransportControls.");
        }
    }

    public void SetCanGoPrevious(bool canGoPrevious)
    {
        if (_smtc == null)
        {
            _logger.LogWarning("Unable to set CanGoPrevious because SystemMediaTransportControls is unavailable.");
            return;
        }

        try
        {
            lock (_gate)
            {
                _smtc.IsPreviousEnabled = canGoPrevious;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to set CanGoPrevious on SystemMediaTransportControls.");
        }
    }

    private void OnButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
    {
        switch (args.Button)
        {
            case SystemMediaTransportControlsButton.Play:
                _logger.LogDebug("Windows SMTC requested Play.");
                PlayRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SystemMediaTransportControlsButton.Pause:
                _logger.LogDebug("Windows SMTC requested Pause.");
                PauseRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SystemMediaTransportControlsButton.Next:
                _logger.LogDebug("Windows SMTC requested Next.");
                NextRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SystemMediaTransportControlsButton.Previous:
                _logger.LogDebug("Windows SMTC requested Previous.");
                PreviousRequested?.Invoke(this, EventArgs.Empty);
                break;
            default:
                break;
        }
    }
}
