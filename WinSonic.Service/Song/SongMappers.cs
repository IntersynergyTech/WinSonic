using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Service.Album;
using WinSonic.Service.Artist;
using Api = WinSonic.Subsonic.Client.Model;

namespace WinSonic.Service.Song;

public static class SongMappers
{
    public static Core.Models.Song ApiToSong(Api.Child song)
    {
        if (song.MediaType != Api.MediaType.Song)
        {
            throw new ArgumentException("The provided child is not a song.");
        }

        return new Core.Models.Song(
            song.Id,
            null, //todo maybe in future or just nuke
            song.AlbumId,
            song.Artist,
            song.Artists.ConvertArray(ArtistMappers.ApiToArtist),
            song.CoverArt,
            TimeSpan.FromSeconds(song.Duration),
            song.ApiIsExplicit(),
            ApiToReplayGain(song.ReplayGain),
            song.Title,
            null,
            null
        );
    }

    public static bool ApiIsExplicit(this Api.Child child)
    {
        return child.ExplicitStatus == Api.ExplicitStatus.Explicit;
    }

    public static ReplayGain ApiToReplayGain(Api.ReplayGain replayGain)
    {
        return new ReplayGain(replayGain.TrackGain, replayGain.TrackPeak, replayGain.AlbumGain, replayGain.AlbumPeak);
    }

    public static Core.Models.Song DbToSong(Data.DbModels.DbSong dbSong)
    {
        return new Core.Models.Song(
            dbSong.Id,
            AlbumMappers.DbToAlbumInfo(dbSong.Album),
            dbSong.Album?.Id,
            dbSong.Artist?.Title,
            dbSong.Artists?.ConvertArray(ArtistMappers.DbToArtist) ?? Array.Empty<Core.Models.Artist>(),
            dbSong.CoverArt?.Id,
            TimeSpan.FromSeconds(dbSong.Duration??0),
            dbSong.IsExplicit,
            new ReplayGain(dbSong.RgTrackGain, dbSong.RgTrackPeak, dbSong.RgAlbumGain, dbSong.RgAlbumPeak),
            dbSong.Title,
            dbSong.DiscNumber,
            dbSong.Track
        );
    }
}
