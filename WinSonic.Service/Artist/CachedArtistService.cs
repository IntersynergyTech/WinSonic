using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Core.Models;
using WinSonic.Data;
using WinSonic.Service.Album;
using WinSonic.Service.Song;
using ArtistModel = WinSonic.Core.Models.Artist;
using SongModel = WinSonic.Core.Models.Song;

namespace WinSonic.Service.Artist;

public class CachedArtistService : IArtistService
{
    private readonly BaseDataContext _dataContext;
    private readonly ILogger<CachedArtistService> _logger;

    public CachedArtistService(BaseDataContext dataContext, ILogger<CachedArtistService> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<ArtistModel>> GetArtistsAsync()
    {
        _logger.LogDebug("Fetching artists from database");
        var dbArtists = await _dataContext.Artists.ToListAsync();
        return dbArtists.ConvertList(ArtistMappers.DbToArtist);
    }

    public async Task<IReadOnlyCollection<SongModel>> GetSongsByArtistAsync(string artistId)
    {
        _logger.LogDebug($"Fetching songs for artist {artistId} from database");

        try
        {
            var dbSongs = await _dataContext.Songs
                .Include(s => s.CoverArt)
                .Include(s => s.Album)
                .Include(s => s.Artist)
                .Include(s => s.Artists)
                .Where(s => (s.Artist != null && s.Artist.Id == artistId)
                    //|| (s.Artists != null && s.Artists.Any(a => a.Id == artistId))
                    //|| (s.AlbumArtists != null && s.AlbumArtists.Any(a => a.Id == artistId))
                )
                .ToListAsync();

            return dbSongs.ConvertList(SongMappers.DbToSong);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error fetching songs for artist {artistId}");
            return Array.Empty<SongModel>();
        }
    }

    public async Task<IReadOnlyCollection<AlbumInfo>> GetAlbumsByArtistAsync(string artistId)
    {
        _logger.LogDebug($"Fetching albums for artist {artistId} from database");

        try
        {
            var dbAlbums = await _dataContext.Albums
                .Include(a => a.CoverArt)
                .Include(a => a.Artists)
                .Where(a => a.Artists.Any(ar => ar.Id == artistId))
                .ToListAsync();

            return dbAlbums.ConvertList(AlbumMappers.DbToAlbumInfo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error fetching albums for artist {artistId}");
            return Array.Empty<AlbumInfo>();
        }
    }
}
