using Api = WinSonic.Subsonic.Client.Model;
namespace WinSonic.Service.Artist;

public static class ArtistMappers
{
    public static Core.Models.Artist ApiToArtist(Api.ArtistID3 artist)
    {
        return new Core.Models.Artist(artist.Id, artist.Name, artist.SortName);
    }

    public static Core.Models.Artist DbToArtist(Data.DbModels.DbArtist artist)
    {
        return new Core.Models.Artist(artist.Id, artist.Title, artist.SortTitle);
    }
}
