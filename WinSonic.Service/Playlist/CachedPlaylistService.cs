using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Data;

namespace WinSonic.Service.Playlist;

public class CachedPlaylistService : IPlaylistService
{
    private readonly BaseDataContext _dataContext;
    private readonly ILogger<CachedPlaylistService> _logger;

    public CachedPlaylistService(BaseDataContext dataContext, ILogger<CachedPlaylistService> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<PlaylistFull> GetPlaylistByIdAsync(string id)
    {
        _logger.LogDebug($"Requesting playlist {id} from Database");

        var dbPlaylist = await _dataContext.Playlists
            .Include(p => p.Songs)
            .ThenInclude(s => s.CoverArt)
            .Include(p => p.Songs)
            .ThenInclude(s => s.Album)
            .Include(p => p.Songs)
            .ThenInclude(s => s.Artist)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (dbPlaylist == null)
        {
            throw new InvalidOperationException("Playlist not found.");
        }

        return dbPlaylist.DbToPlaylistFull();
    }

    public async Task<IReadOnlyCollection<PlaylistInfo>> GetPlaylistsAsync()
    {
        _logger.LogDebug("Fetching playlists from database");
        var dbPlaylists = await _dataContext.Playlists.Include(p => p.CoverArt).ToListAsync();

        var mappedPlaylists = dbPlaylists.ConvertList(PlaylistMappers.DbToPlaylistInfo);
        return mappedPlaylists;
    }
}
