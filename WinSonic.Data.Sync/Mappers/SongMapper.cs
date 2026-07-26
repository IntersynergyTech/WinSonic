using WinSonic.Data.DbModels;
using WinSonic.Data.Enums;
using Child = WinSonic.Subsonic.Client.Model.Child;

namespace WinSonic.Data.Sync.Mappers;

public static class SongMapper
{
    public static Song CreateDbSong(
        this Child source,
        Album? existingAlbum,
        Artist? existingArtist,
        Dictionary<string,Artist> existingArtists
    )
    {
        var song = new DbModels.Song
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
            Filesize = source.Size
        };

        song.AddDefaultCacheables();

        if (source.Year != 0)
        {
            song.ReleaseDate = new DateTime(source.Year, 1, 1);
            song.ReleaseDateType = ReleaseDateType.Year;
        }

        song.Artist = existingArtist;

        song.Artists = new List<Artist>();
        song.AlbumArtists = new List<Artist>();

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
            var coverArt = new CoverArt(source.CoverArt).AddDefaultCacheables();
            song.CoverArt = coverArt;
        }

        song.Album = existingAlbum;

        return song;
    }
}
