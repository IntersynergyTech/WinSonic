using WinSonic.Core.Models;
using WinSonic.Data.DbModels;

namespace WinSonic.Data.Sync.Mappers;

public static class ServiceMappers
{
    public static Core.Models.Song ToSong(DbSong song)
    {
        return new Core.Models.Song(
            song.Id,
            ToAlbumInfo(song.Album),
            song.Album.Id,
            song.Artist?.Title,
            Array.Empty<Core.Models.Artist>(),
            song.CoverArt?.Id,
            TimeSpan.FromSeconds(song.Duration ?? 0),
            song.IsExplicit,
            new ReplayGain(song.RgAlbumGain, song.RgAlbumPeak, song.RgTrackGain, song.RgTrackPeak),
            song.Title
        );
    }
    
    public static Core.Models.AlbumInfo? ToAlbumInfo(DbAlbum? album)
    {
        if (album == null)
        {
            return null;
        }
        
        return new Core.Models.AlbumInfo(
            album.Id,
            album.Title,
            album.SortTitle,
            album.ArtistName,
            album.CoverArt?.Id,
            album.SongCount,
            TimeSpan.FromSeconds(album.Duration),
            album.ReleaseDate?.Year,
            album.IsExplicit
        );
    }
}
