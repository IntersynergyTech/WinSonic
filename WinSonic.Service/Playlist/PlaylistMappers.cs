using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Service.Song;
using Api = WinSonic.Subsonic.Client.Model;

namespace WinSonic.Service.Playlist;

public static class PlaylistMappers
{
    public static PlaylistFull ApiToPlaylistFull(this Api.PlaylistWithSongs playlist)
    {
        return new PlaylistFull(
            id: playlist.Id,
            name: playlist.Name,
            songCount: playlist.SongCount,
            duration: TimeSpan.FromSeconds(playlist.Duration),
            created: playlist.Created,
            changed: playlist.Changed,
            comment: playlist.Comment,
            owner: playlist.Owner,
            isPublic: playlist.Public,
            coverArtId: playlist.CoverArt,
            isReadOnly: playlist.Readonly,
            entries: playlist.Entry.ConvertList(SongMappers.ApiToSong)
        );
    }

    public static PlaylistInfo ApiToPlaylistInfo(this Api.Playlist playlist)
    {
        return new PlaylistInfo(
            id: playlist.Id,
            name: playlist.Name,
            songCount: playlist.SongCount,
            duration: TimeSpan.FromSeconds(playlist.Duration),
            created: playlist.Created,
            changed: playlist.Changed,
            comment: playlist.Comment,
            owner: playlist.Owner,
            isPublic: playlist.Public,
            coverArtId: playlist.CoverArt,
            isReadOnly: playlist.Readonly
        );
    }

    public static PlaylistInfo DbToPlaylistInfo(this Data.DbModels.DbPlaylist playlist)
    {
        return new PlaylistInfo(
            id: playlist.Id,
            name: playlist.Title,
            songCount: playlist.SongCount,
            duration: TimeSpan.FromSeconds(playlist.Duration),
            created: playlist.CreatedAt,
            changed: playlist.UpdatedAt,
            comment: "playlist.Comment", //todo
            owner: playlist.Owner,
            isPublic: playlist.IsPublic,
            coverArtId: playlist.CoverArt?.Id,
            isReadOnly: playlist.IsReadOnly
        );
    }

    public static PlaylistFull DbToPlaylistFull(this Data.DbModels.DbPlaylist playlist)
    {
        
        var songs = playlist.Songs.ConvertList(SongMappers.DbToSong);
        
        return new PlaylistFull(
            id: playlist.Id,
            name: playlist.Title,
            songCount: playlist.SongCount,
            duration: TimeSpan.FromSeconds(playlist.Duration),
            created: playlist.CreatedAt,
            changed: playlist.UpdatedAt,
            comment: "playlist.Comment", //todo
            owner: playlist.Owner,
            isPublic: playlist.IsPublic,
            coverArtId: playlist.CoverArt?.Id,
            isReadOnly: playlist.IsReadOnly, 
            entries: songs
        );
    }
}
