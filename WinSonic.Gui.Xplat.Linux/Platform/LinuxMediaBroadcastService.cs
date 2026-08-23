using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tmds.DBus;
using WinSonic.Playback.Platform;

namespace WinSonic.Gui.Xplat.Linux.Platform;

public class LinuxMediaBroadcastService : ISystemMediaBroadcastService
{
    private const string ServiceName = "org.mpris.MediaPlayer2.winsonic";
    private static readonly ObjectPath MprisObjectPath = new("/org/mpris/MediaPlayer2");
    private readonly ILogger<LinuxMediaBroadcastService> _logger;
    private Connection? _connection;
    private MprisObject? _mprisObject;
    private readonly SemaphoreSlim _initGate = new(1, 1);

    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public LinuxMediaBroadcastService(ILogger<LinuxMediaBroadcastService> logger)
    {
        _logger = logger;
    }

    public void BroadcastMediaInfo(
        string mediaTitle,
        string mediaArtist,
        string mediaAlbum,
        string? coverArtUrl = null
    )
    {
        _ = BroadcastMediaInfoInternalAsync(mediaTitle, mediaArtist, mediaAlbum, coverArtUrl);
    }

    public void BroadcastVolume(float volume)
    {
        _ = BroadcastVolumeInternalAsync(volume);
    }

    public void SetCanGoNext(bool canGoNext)
    {
        _ = SetCanGoNextInternalAsync(canGoNext);
    }

    public void SetCanGoPrevious(bool canGoPrevious)
    {
        _ = SetCanGoPreviousInternalAsync(canGoPrevious);
    }

    private async Task BroadcastMediaInfoInternalAsync(string mediaTitle, string mediaArtist, string mediaAlbum, string? coverArtUrl)
    {
        if (!await EnsureInitializedAsync().ConfigureAwait(false))
        {
            _logger.LogWarning("Unable to broadcast media info because MPRIS initialization failed.");
            return;
        }

        try
        {
            _mprisObject!.UpdateMetadata(mediaTitle, mediaArtist, mediaAlbum, coverArtUrl);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to broadcast media info to MPRIS.");
        }
    }

    private async Task BroadcastVolumeInternalAsync(float volume)
    {
        if (!await EnsureInitializedAsync().ConfigureAwait(false))
        {
            _logger.LogWarning("Unable to broadcast volume because MPRIS initialization failed.");
            return;
        }

        try
        {
            _mprisObject!.UpdateVolume(volume);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to broadcast volume to MPRIS.");
        }
    }

    private async Task SetCanGoNextInternalAsync(bool canGoNext)
    {
        if (!await EnsureInitializedAsync().ConfigureAwait(false))
        {
            _logger.LogWarning("Unable to set MPRIS CanGoNext because initialization failed.");
            return;
        }

        try
        {
            _mprisObject!.UpdateCanGoNext(canGoNext);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to set MPRIS CanGoNext.");
        }
    }

    private async Task SetCanGoPreviousInternalAsync(bool canGoPrevious)
    {
        if (!await EnsureInitializedAsync().ConfigureAwait(false))
        {
            _logger.LogWarning("Unable to set MPRIS CanGoPrevious because initialization failed.");
            return;
        }

        try
        {
            _mprisObject!.UpdateCanGoPrevious(canGoPrevious);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to set MPRIS CanGoPrevious.");
        }
    }

    private async Task<bool> EnsureInitializedAsync()
    {
        if (_connection != null && _mprisObject != null)
        {
            return true;
        }

        await _initGate.WaitAsync().ConfigureAwait(false);

        try
        {
            if (_connection != null && _mprisObject != null)
            {
                return true;
            }

            _connection = new Connection(Address.Session);
            await _connection.ConnectAsync();

            _mprisObject = new MprisObject(MprisObjectPath);
            _mprisObject.PlayRequested += (_, _) =>
            {
                _logger.LogDebug("MPRIS requested Play.");
                PlayRequested?.Invoke(this, EventArgs.Empty);
            };
            _mprisObject.PauseRequested += (_, _) =>
            {
                _logger.LogDebug("MPRIS requested Pause.");
                PauseRequested?.Invoke(this, EventArgs.Empty);
            };
            _mprisObject.NextRequested += (_, _) =>
            {
                _logger.LogDebug("MPRIS requested Next.");
                NextRequested?.Invoke(this, EventArgs.Empty);
            };
            _mprisObject.PreviousRequested += (_, _) =>
            {
                _logger.LogDebug("MPRIS requested Previous.");
                PreviousRequested?.Invoke(this, EventArgs.Empty);
            };
            _mprisObject.SetVolumeRequested += (_, volume) =>
            {
                _logger.LogDebug("MPRIS requested volume change to {Volume}.", volume);
                SetVolumeRequested?.Invoke(this, volume);
            };
            await _connection.RegisterObjectAsync(_mprisObject);
            await _connection.RegisterServiceAsync(ServiceName);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to initialize Linux MPRIS broadcast service.");
            _connection = null;
            _mprisObject = null;
            return false;
        }
        finally
        {
            _initGate.Release();
        }
    }
}

[DBusInterface("org.mpris.MediaPlayer2", GetPropertyMethod = nameof(GetRootPropertyAsync), SetPropertyMethod = nameof(SetRootPropertyAsync), GetAllPropertiesMethod = nameof(GetAllRootPropertiesAsync), WatchPropertiesMethod = nameof(WatchRootPropertiesAsync))]
public interface IMprisRoot : IDBusObject
{
    Task RaiseAsync();
    Task QuitAsync();
    Task<object> GetRootPropertyAsync(string prop);
    Task SetRootPropertyAsync(string prop, object val);
    Task<IDictionary<string, object>> GetAllRootPropertiesAsync();
    Task<IDisposable> WatchRootPropertiesAsync(Action<PropertyChanges> handler);
}

[DBusInterface("org.mpris.MediaPlayer2.Player", GetPropertyMethod = nameof(GetPlayerPropertyAsync), SetPropertyMethod = nameof(SetPlayerPropertyAsync), GetAllPropertiesMethod = nameof(GetAllPlayerPropertiesAsync), WatchPropertiesMethod = nameof(WatchPlayerPropertiesAsync))]
public interface IMprisPlayer : IDBusObject
{
    Task NextAsync();
    Task PreviousAsync();
    Task PauseAsync();
    Task PlayPauseAsync();
    Task StopAsync();
    Task PlayAsync();
    Task SeekAsync(long offset);
    Task SetPositionAsync(ObjectPath trackId, long position);
    Task OpenUriAsync(string uri);

    Task<object> GetPlayerPropertyAsync(string prop);
    Task SetPlayerPropertyAsync(string prop, object val);
    Task<IDictionary<string, object>> GetAllPlayerPropertiesAsync();
    Task<IDisposable> WatchPlayerPropertiesAsync(Action<PropertyChanges> handler);
}

public sealed class MprisObject : IMprisRoot, IMprisPlayer
{
    private readonly ObjectPath _objectPath;
    private readonly object _gate = new();
    private IDictionary<string, object> _metadata = EmptyMetadata();
    private long _position;
    private double _volume = 1.0;
    private string _playbackStatus = "Stopped";
    private bool _canGoNext;
    private bool _canGoPrevious;

    public event EventHandler? PlayRequested;
    public event EventHandler? PauseRequested;
    public event EventHandler? NextRequested;
    public event EventHandler? PreviousRequested;
    public event EventHandler<double>? SetVolumeRequested;

    public MprisObject(ObjectPath objectPath)
    {
        _objectPath = objectPath;
    }

    public ObjectPath ObjectPath => _objectPath;

    public event Action<PropertyChanges>? RootPropertiesChanged;
    public event Action<PropertyChanges>? PlayerPropertiesChanged;

    public void UpdateMetadata(string title, string artist, string album, string? coverArtUrl)
    {
        var trackMetadata = new Dictionary<string, object>
        {
            ["mpris:trackid"] = new ObjectPath("/org/mpris/MediaPlayer2/track/current"),
            ["xesam:title"] = title,
            ["xesam:artist"] = string.IsNullOrWhiteSpace(artist) ? Array.Empty<string>() : new[] { artist },
            ["xesam:album"] = album
        };

        if (!string.IsNullOrWhiteSpace(coverArtUrl))
        {
            trackMetadata["mpris:artUrl"] = coverArtUrl;
        }

        lock (_gate)
        {
            _metadata = trackMetadata;
            _playbackStatus = string.IsNullOrWhiteSpace(title) ? "Stopped" : "Playing";
        }

        PlayerPropertiesChanged?.Invoke(new PropertyChanges(
            new[]
            {
                new KeyValuePair<string, object>("Metadata", trackMetadata),
                new KeyValuePair<string, object>("PlaybackStatus", _playbackStatus)
            },
            Array.Empty<string>()));
    }

    public void UpdateVolume(float volume)
    {
        _volume = Math.Clamp(volume, 0d, 1d);
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("Volume", _volume));
    }

    public void UpdateCanGoNext(bool canGoNext)
    {
        _canGoNext = canGoNext;
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("CanGoNext", _canGoNext));
    }

    public void UpdateCanGoPrevious(bool canGoPrevious)
    {
        _canGoPrevious = canGoPrevious;
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("CanGoPrevious", _canGoPrevious));
    }

    public Task RaiseAsync() => Task.CompletedTask;
    public Task QuitAsync() => Task.CompletedTask;

    public Task<object> GetRootPropertyAsync(string prop) => Task.FromResult(GetRootProperty(prop));
    public Task SetRootPropertyAsync(string prop, object val) => Task.CompletedTask;

    public Task<IDictionary<string, object>> GetAllRootPropertiesAsync()
    {
        IDictionary<string, object> props = new Dictionary<string, object>
        {
            ["CanQuit"] = false,
            ["Fullscreen"] = false,
            ["CanSetFullscreen"] = false,
            ["CanRaise"] = false,
            ["HasTrackList"] = false,
            ["Identity"] = "WinSonic",
            ["DesktopEntry"] = "winsonic",
            ["SupportedUriSchemes"] = new[] { "file", "http", "https" },
            ["SupportedMimeTypes"] = new[] { "audio/mpeg", "audio/flac", "audio/ogg", "audio/wav" }
        };
        return Task.FromResult(props);
    }

    public Task<IDisposable> WatchRootPropertiesAsync(Action<PropertyChanges> handler) =>
        SignalWatcher.AddAsync(this, nameof(RootPropertiesChanged), handler);

    public Task NextAsync()
    {
        NextRequested?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task PreviousAsync()
    {
        PreviousRequested?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task PauseAsync()
    {
        _playbackStatus = "Paused";
        PauseRequested?.Invoke(this, EventArgs.Empty);
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("PlaybackStatus", _playbackStatus));
        return Task.CompletedTask;
    }

    public Task PlayPauseAsync()
    {
        if (_playbackStatus == "Playing")
        {
            _playbackStatus = "Paused";
            PauseRequested?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            _playbackStatus = "Playing";
            PlayRequested?.Invoke(this, EventArgs.Empty);
        }

        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("PlaybackStatus", _playbackStatus));
        return Task.CompletedTask;
    }
    public Task StopAsync() => Task.CompletedTask;
    public Task PlayAsync()
    {
        _playbackStatus = "Playing";
        PlayRequested?.Invoke(this, EventArgs.Empty);
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("PlaybackStatus", _playbackStatus));
        return Task.CompletedTask;
    }
    public Task SeekAsync(long offset)
    {
        lock (_gate)
        {
            _position = Math.Max(0, _position + offset);
        }
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("Position", _position));
        return Task.CompletedTask;
    }

    public Task SetPositionAsync(ObjectPath trackId, long position)
    {
        lock (_gate)
        {
            _position = Math.Max(0, position);
        }
        PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("Position", _position));
        return Task.CompletedTask;
    }

    public Task OpenUriAsync(string uri) => Task.CompletedTask;

    public Task<object> GetPlayerPropertyAsync(string prop) => Task.FromResult(GetPlayerProperty(prop));

    public Task SetPlayerPropertyAsync(string prop, object val)
    {
        if (prop == "Volume" && val is double volume)
        {
            _volume = Math.Clamp(volume, 0d, 1d);
            SetVolumeRequested?.Invoke(this, _volume);
            PlayerPropertiesChanged?.Invoke(PropertyChanges.ForProperty("Volume", _volume));
        }

        return Task.CompletedTask;
    }

    public Task<IDictionary<string, object>> GetAllPlayerPropertiesAsync()
    {
        IDictionary<string, object> props = new Dictionary<string, object>
        {
            ["PlaybackStatus"] = _playbackStatus,
            ["LoopStatus"] = "None",
            ["Rate"] = 1.0d,
            ["Shuffle"] = false,
            ["Metadata"] = _metadata,
            ["Volume"] = _volume,
            ["Position"] = _position,
            ["MinimumRate"] = 1.0d,
            ["MaximumRate"] = 1.0d,
            ["CanGoNext"] = _canGoNext,
            ["CanGoPrevious"] = _canGoPrevious,
            ["CanPlay"] = true,
            ["CanPause"] = true,
            ["CanSeek"] = false,
            ["CanControl"] = true
        };
        return Task.FromResult(props);
    }

    public Task<IDisposable> WatchPlayerPropertiesAsync(Action<PropertyChanges> handler) =>
        SignalWatcher.AddAsync(this, nameof(PlayerPropertiesChanged), handler);

    private static IDictionary<string, object> EmptyMetadata()
    {
        return new Dictionary<string, object>
        {
            ["mpris:trackid"] = new ObjectPath("/org/mpris/MediaPlayer2/track/none"),
            ["xesam:title"] = string.Empty,
            ["xesam:artist"] = Array.Empty<string>(),
            ["xesam:album"] = string.Empty
        };
    }

    private object GetRootProperty(string prop)
    {
        return prop switch
        {
            "CanQuit" => false,
            "Fullscreen" => false,
            "CanSetFullscreen" => false,
            "CanRaise" => false,
            "HasTrackList" => false,
            "Identity" => "WinSonic",
            "DesktopEntry" => "winsonic",
            "SupportedUriSchemes" => new[] { "file", "http", "https" },
            "SupportedMimeTypes" => new[] { "audio/mpeg", "audio/flac", "audio/ogg", "audio/wav" },
            _ => throw new ArgumentOutOfRangeException(nameof(prop), prop, null)
        };
    }

    private object GetPlayerProperty(string prop)
    {
        return prop switch
        {
            "PlaybackStatus" => _playbackStatus,
            "LoopStatus" => "None",
            "Rate" => 1.0d,
            "Shuffle" => false,
            "Metadata" => _metadata,
            "Volume" => _volume,
            "Position" => _position,
            "MinimumRate" => 1.0d,
            "MaximumRate" => 1.0d,
            "CanGoNext" => _canGoNext,
            "CanGoPrevious" => _canGoPrevious,
            "CanPlay" => true,
            "CanPause" => true,
            "CanSeek" => false,
            "CanControl" => true,
            _ => throw new ArgumentOutOfRangeException(nameof(prop), prop, null)
        };
    }
}
