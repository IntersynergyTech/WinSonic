using WinSonic.Data.DbModels;
using WinSonic.Data.Utilities;
using WinSonic.Subsonic.Client.Model;

namespace WinSonic.Data.Sync.Mappers;

public static class ArtistMapper
{
    public static DbArtist CreateDbArtist(this ArtistID3 source)
    {
        var artist = new DbArtist
        {
            Id = source.Id,
            Title = source.Name,
            AlbumCount = source.AlbumCount,
            StarredAt = source.Starred,
            SortTitle = source.SortName,
            Types = source.Roles
        };

        if (!string.IsNullOrEmpty(source.CoverArt))
        {
            var coverArt = new DbCoverArt(source.CoverArt).AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);
            artist.CoverArt = coverArt;
        }

        artist.AddDefaultCacheables(SyncManager.DefaultCacheExpiryMins);

        return artist;
    }
}
