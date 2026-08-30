using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WinSonic.Core.Models;
using WinSonic.Gui.Common.GuiServices;
using WinSonic.Gui.Common.Messages;

namespace WinSonic.Gui.Common.ViewModels.Components;

/// <summary>
///  You should not use this class directly, instead use one of the subclasses like AlbumTrackListEntry or PlaylistTrackListEntry.
/// </summary>
public partial class TrackListEntry : ObservableObject
{
    public TrackListEntry(Song song, TrackListingType type)
    {
        Song = song;
        Type = type;
    }

    public Song Song { get; set; }
    public TrackListingType Type { get; set; }

    [RelayCommand]
    public void PlayContext(bool shuffle)
    {
        Task.Run(() =>
        {
            var message = GetPlayContextMessage(shuffle);
            TrackContextService.SendPlayRequest(message);
        });
    }

    [RelayCommand]
    public void QueueNext()
    {
        RequestQueue(TrackContextQueueMessage.TrackContextQueueType.PlayNext);
    }

    [RelayCommand]
    public void AddToQueue()
    {
        RequestQueue(TrackContextQueueMessage.TrackContextQueueType.AddToQueue);
    }

    private void RequestQueue(TrackContextQueueMessage.TrackContextQueueType queueType)
    {
        var request = new TrackContextQueueMessage(Song, queueType);
        TrackContextService.SendQueueRequest(request);
    }

    protected virtual TrackContextPlayMessage GetPlayContextMessage(bool shuffle)
    {
        // Default implementation does nothing, subclasses can override this to provide specific behavior
        return null;
    }
    
    public static implicit operator Song(TrackListEntry entry) => entry.Song;
}

public class AlbumTrackListEntry : TrackListEntry
{
    public AlbumTrackListEntry(Song song, AlbumFull album) : base(song, TrackListingType.AlbumView)
    {
        Album = album;
    }

    public AlbumFull Album { get; set; }

    protected override TrackContextPlayMessage GetPlayContextMessage(bool shuffle)
    {
        var request = new TrackContextPlayMessage(Album, Song, shuffle);
        return request;
    }
}

public class PlaylistTrackListEntry : TrackListEntry
{
    public PlaylistTrackListEntry(Song song, PlaylistFull playlist) : base(song, TrackListingType.PlaylistView)
    {
        Playlist = playlist;
    }

    public PlaylistFull Playlist { get; set; }

    protected override TrackContextPlayMessage GetPlayContextMessage(bool shuffle)
    {
        var request = new TrackContextPlayMessage(Playlist, Song, shuffle);
        return request;
    }
}

public enum TrackListingType
{
    General,
    AlbumView,
    PlaylistView,
    ArtistView,
}
