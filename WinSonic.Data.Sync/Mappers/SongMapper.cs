using WinSonic.Data.DbModels;
using WinSonic.Data.Enums;
using WinSonic.Data.Utilities;
using Child = WinSonic.Subsonic.Client.Model.Child;

namespace WinSonic.Data.Sync.Mappers;

public static class SongMapper
{
    public static DbSong CreateDbSong(
        this Child source,
        DbAlbum? existingAlbum,
        DbArtist? existingArtist,
        Dictionary<string,DbArtist> existingArtists
    )
    {
        var song = new DbModels.DbSong
        {
            Id = source.Id,
            Title = source.Title,
            DisplayAlbumArtist = source.DisplayAlbumArtist,
            DisplayArtist = source.DisplayArtist,
            Track = source.Track,
            Genre = source.Genre,
            Comment = source.Comment,
            SortTitle = source.SortName,
            Bpm = source.Bpm,
            Rating = source.UserRating,
            StarredAt = source.Starred,
            SampleRate = source.SamplingRate,
            BitDepth = source.BitDepth,
            Bitrate = source.BitRate,
            ChannelCount = source.ChannelCount,
            Filesize = source.Size,
            Duration = source.Duration,
            DiscNumber = source.DiscNumber,
            RgAlbumGain = source.ReplayGain.AlbumGain,
            RgTrackGain = source.ReplayGain.TrackGain,
            RgAlbumPeak = source.ReplayGain.AlbumPeak,
            RgTrackPeak = source.ReplayGain.TrackPeak
        };

        song.AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);

        if (source.Year != 0)
        {
            song.ReleaseDate = new DateTime(source.Year, 1, 1);
            song.ReleaseDateType = ReleaseDateType.Year;
        }

        song.Artist = existingArtist;

        song.Artists = new List<DbArtist>();
        song.AlbumArtists = new List<DbArtist>();

        foreach (var sourceArtist in source.Artists)
        {
            var songExistingArtist = existingArtists.GetValueOrDefault(sourceArtist.Id);
            if (songExistingArtist != null) song.Artists.Add(songExistingArtist);
        }

        foreach (var sourceArtist in source.AlbumArtists)
        {
            var songExistingArtist = existingArtists.GetValueOrDefault(sourceArtist.Id);
            if (songExistingArtist != null) song.AlbumArtists.Add(songExistingArtist);
        }

        if (!string.IsNullOrEmpty(source.CoverArt))
        {
            var coverArt = new DbCoverArt(source.CoverArt).AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);
            song.CoverArt = coverArt;
        }

        song.Album = existingAlbum;

        return song;
    }
}
