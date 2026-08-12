using WinSonic.Core.Models;

namespace WinSonic.Service.Album;

public interface IAlbumService
{
    public Task<IReadOnlyCollection<AlbumInfo>> GetAlbumsAsync();
    public Task<AlbumFull> GetAlbumByIdAsync(string albumId);
}
