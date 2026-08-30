using WinSonic.Core.Models;

namespace WinSonic.Gui.Common.Messages;

public class TrackContextPlayMessage
{
    public TrackContextPlayMessage(AlbumFull album, Song? initialSong = null, bool shuffle = false)
    {
        AlbumContext = album;
        InitialSong = initialSong;
        Shuffle = shuffle;
        Type = TrackContextType.Album;
    }

    public TrackContextPlayMessage(PlaylistFull playlist, Song? initialSong = null, bool shuffle = false)
    {
        PlaylistContext = playlist;
        InitialSong = initialSong;
        Shuffle = shuffle;
        Type = TrackContextType.Playlist;
    }

    public TrackContextPlayMessage(ICollection<Song> songs, Song? initialSong = null, bool shuffle = false)
    {
        GeneralContext = songs;
        InitialSong = initialSong;
        Shuffle = shuffle;
        Type = TrackContextType.General;
    }

    private Song? InitialSong { get; }
    private AlbumFull? AlbumContext { get; }
    private PlaylistFull? PlaylistContext { get; }
    private ICollection<Song>? GeneralContext { get; }
    private bool Shuffle { get; }
    private TrackContextType Type { get; }

    private enum TrackContextType
    {
        Album,
        Playlist,
        General,
    }

    public ICollection<Song>? GetSongs()
    {
        var songs = Type switch
        {
            TrackContextType.Album => AlbumContext?.Songs,
            TrackContextType.Playlist => PlaylistContext?.Entries,
            TrackContextType.General => GeneralContext,
            _ => throw new InvalidOperationException($"Unknown track context type: {Type}")
        };

        if (!Shuffle)
        {
            // Skip anything in the context that comes before the initial song, if one is specified
            if (InitialSong != null)
            {
                var initialSongIndex = songs!.ToList().FindIndex(s => s.Id == InitialSong.Id);
                if (initialSongIndex >= 0)
                {
                    return songs!.Skip(initialSongIndex).ToList();
                }
            }

            return songs;
        }

        // Shuffle the songs if shuffle is enabled, but make sure the initial song is first if one is specified

        var shuffledSongs = songs.OrderBy(s => Guid.NewGuid()).ToList();
        if (InitialSong != null)
        {
            shuffledSongs.RemoveAll(s => s.Id == InitialSong.Id);
            shuffledSongs.Insert(0, InitialSong);
        }
        return shuffledSongs;
    }
}


