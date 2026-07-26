using WinSonic.Data.DbModels;
using WinSonic.Subsonic.Client.Model;
using Artist = WinSonic.Data.DbModels.Artist;

namespace WinSonic.Data.Sync.Mappers;

public static class ArtistMapper
{
    public static Artist CreateDbArtist(this ArtistID3 source)
    {
        var artist = new Artist
        {
            Id = source.Id,
            Title = source.Name,
            AlbumCount = source.AlbumCount,
            StarredAt = source.Starred,
            SortTitle = source.SortName,
        };

        if (!string.IsNullOrEmpty(source.CoverArt))
        {
            var coverArt = new CoverArt(source.CoverArt).AddDefaultCacheables();
            artist.CoverArt = coverArt;
        }

        artist.AddDefaultCacheables();

        return artist;
    }
}
