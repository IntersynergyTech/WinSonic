using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Service.Song;

namespace WinSonic.Service.Album;

public static class AlbumMappers
{
    public static AlbumInfo DbToAlbumInfo(this Data.DbModels.DbAlbum album)
    {
        return new AlbumInfo(
            id: album.Id,
            title: album.Title,
            sortTitle: album.SortTitle,
            artist: album.DisplayArtist,
            coverArtId: album.CoverArt?.Id,
            songCount: album.SongCount,
            duration: TimeSpan.FromSeconds(album.Duration),
            year: album.ReleaseDate?.Year,
            isExplicit: album.IsExplicit
        );
    }

    public static AlbumFull DbToAlbumFull(this Data.DbModels.DbAlbum album)
    {
        var songs = album.Songs.ConvertList(SongMappers.DbToSong);

        return new AlbumFull(
            id: album.Id,
            title: album.Title,
            sortTitle: album.SortTitle,
            artist: album.DisplayArtist,
            coverArtId: album.CoverArt?.Id,
            songCount: album.SongCount,
            duration: TimeSpan.FromSeconds(album.Duration),
            year: album.ReleaseDate?.Year,
            isExplicit: album.IsExplicit,
            songs: songs
        );
    }
}
