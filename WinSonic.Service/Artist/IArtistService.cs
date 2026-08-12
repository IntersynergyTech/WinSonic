using WinSonic.Core.Models;
using ArtistModel = WinSonic.Core.Models.Artist;
using SongModel = WinSonic.Core.Models.Song;

namespace WinSonic.Service.Artist;

public interface IArtistService
{
    public Task<IReadOnlyCollection<ArtistModel>> GetArtistsAsync();
    public Task<IReadOnlyCollection<SongModel>> GetSongsByArtistAsync(string artistId);
    public Task<IReadOnlyCollection<AlbumInfo>> GetAlbumsByArtistAsync(string artistId);
}
