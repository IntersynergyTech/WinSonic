using WinSonic.Core.Models;

namespace WinSonic.Service.Playlist;

public interface IPlaylistService
{
    public Task<PlaylistFull> GetPlaylistByIdAsync(string id);
    public Task<IReadOnlyCollection<PlaylistInfo>> GetPlaylistsAsync();
}
