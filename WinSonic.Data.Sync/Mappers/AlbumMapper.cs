using WinSonic.Data.DbModels;
using WinSonic.Data.Utilities;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync.Mappers;

public static class AlbumMapper
{
    public static DbAlbum CreateDbAlbum(
        this AlbumID3 source,
        DbArtist existingArtist,
        Dictionary<string, DbArtist> existingArtists
    )
    {
        var album = new DbAlbum
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
            ReleaseDate = source.ReleaseDate.ToDateTime(),
            Rating = source.UserRating
        };

        album.AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);

        if (!string.IsNullOrEmpty(source.CoverArt))
        {
            var coverArt = new DbCoverArt(source.CoverArt).AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);
            album.CoverArt = coverArt;
        }

        var media = source.DiscTitles
            .Select(x => new DbAlbumMedia
                {
                    Name = x.Title,
                    CoverArt = new DbCoverArt(x.CoverArt).AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins)
                }
            )
            .ToList();

        album.Media = media;
        album.Artists = new List<DbArtist>();

        foreach (var sourceArtist in source.Artists)
        {
            var albumExistingArtist = existingArtists.GetValueOrDefault(sourceArtist.Id);
            if (albumExistingArtist != null) album.Artists.Add(albumExistingArtist);
        }

        return album;
    }
}
