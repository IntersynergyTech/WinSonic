using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Data;
using WinSonic.Service.Song;

namespace WinSonic.Service.Album;

public class CachedAlbumService : IAlbumService
{
    private readonly BaseDataContext _dataContext;
    private readonly ILogger<CachedAlbumService> _logger;

    public CachedAlbumService(BaseDataContext dataContext, ILogger<CachedAlbumService> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<AlbumInfo>> GetAlbumsAsync()
    {
        _logger.LogDebug("Fetching albums from database");
        var dbAlbums = await _dataContext.Albums.Include(a => a.CoverArt).ToListAsync();
        return dbAlbums.ConvertList(AlbumMappers.DbToAlbumInfo);
    }

    public async Task<AlbumFull> GetAlbumByIdAsync(string albumId)
    {
        _logger.LogDebug($"Requesting album {albumId} from database");

        var dbAlbum = await _dataContext.Albums
            .Include(a => a.CoverArt)
            .Include(a => a.Songs)
            .ThenInclude(s => s.CoverArt)
            .Include(a => a.Songs)
            .ThenInclude(s => s.Artist)
            .Include(a => a.Songs)
            .ThenInclude(s => s.Artists)
            .SingleOrDefaultAsync(a => a.Id == albumId);

        if (dbAlbum == null)
        {
            throw new InvalidOperationException("Album not found.");
        }

        dbAlbum.Songs = dbAlbum.Songs.OrderBy(s => s.DiscNumber??0).ThenBy(s => s.Track??0).ToList();

        return dbAlbum.DbToAlbumFull();
    }
}
