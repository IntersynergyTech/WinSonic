using WinSonic.Data.DbModels;
using WinSonic.Subsonic.Client.Model;
using Artist = WinSonic.Data.DbModels.Artist;

namespace WinSonic.Data.Sync.Mappers;

public static class AlbumMapper
{
    public static Album CreateDbAlbum(
        this AlbumID3 source,
        Artist existingArtist,
        Dictionary<string,Artist> existingArtists
    )
    {
        var album = new Album
        {
            Id = source.Id,
            Title = source.Name,
            SortTitle = source.SortName,
            Version = source.VarVersion,
            ArtistName = source.Artist,
            SongCount = source.SongCount,
            Duration = source.Duration,
            CreatedAt = source.Created,
            StarredAt = source.Starred,
            PlayedAt = source.Played,
            DisplayArtist = source.DisplayArtist,
            IsCompilation = source.IsCompilation,
            IsExplicit = source.ExplicitStatus == ExplicitStatus.Explicit,
            Rating = source.UserRating
        };

        album.AddDefaultCacheables();

        if (!string.IsNullOrEmpty(source.CoverArt))
        {
            var coverArt = new CoverArt(source.CoverArt).AddDefaultCacheables();
            album.CoverArt = coverArt;
        }

        var media = source.DiscTitles
            .Select(x => new AlbumMedia { Name = x.Title, CoverArt = new CoverArt(x.CoverArt).AddDefaultCacheables() })
            .ToList();

        album.Media = media;
        album.Artists = new List<Artist>();

        foreach (var sourceArtist in source.Artists)
        {
            var albumExistingArtist = existingArtists.GetValueOrDefault(sourceArtist.Id);
            if (albumExistingArtist != null) album.Artists.Add(albumExistingArtist);
        }

        return album;
    }
}
