using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.DbModels.LocalCacheEntries;
using WinSonic.Data.Utilities;

namespace WinSonic.Service.Song;

public class CachedSongService : ISongService
{
    private readonly StorageManager _storageManager;
    private readonly IDbContextFactory<BaseDataContext> _dataContextFactory;
    private readonly LiveSongService _liveSongService;
    private readonly ILogger<CachedSongService> _logger;

    private const int SongCacheExpiryMins = 525600; // 1 year in minutes
    private const int MaxConcurrentLiveSongRequests = 4;
    private static readonly SemaphoreSlim LiveSongThrottle = new(MaxConcurrentLiveSongRequests, MaxConcurrentLiveSongRequests);

    public CachedSongService(
        StorageManager storageManager,
        IDbContextFactory<BaseDataContext> dataContextFactory,
        LiveSongService liveSongService,
        ILogger<CachedSongService> logger
    )
    {
        _storageManager = storageManager;
        _dataContextFactory = dataContextFactory;
        _liveSongService = liveSongService;
        _logger = logger;
    }

    public async Task<Stream> GetSongAsync(
        string songId,
        SongRequest? request = null,
        bool acceptAnyCached = true,
        CancellationToken cancellationToken = default
    )
    {
        var normalizedRequest = NormalizeRequest(request);
        using var dbContext = _dataContextFactory.CreateDbContext();
        var cachedResults = await GetCachedSongsForIdAsync(songId, dbContext, cancellationToken);

        _logger.LogDebug(
            "Getting cached song {SongId} with format={Format}, maxBitRate={BitRate}, original={Original}. Cached entries: {CachedCount}",
            songId,
            normalizedRequest.Format,
            normalizedRequest.MaxBitRate,
            IsOriginalRequest(normalizedRequest),
            cachedResults.Count
        );

        // If we have an original source cached, always return it.
        var originalEntry = cachedResults.FirstOrDefault(c => c.IsOriginal);
        if (originalEntry != null && TryFile(originalEntry, out var originalStream))
        {
            _logger.LogDebug("Cache hit for song {SongId}: returning original cached copy.", songId);
            return originalStream;
        }

        var exact = cachedResults.FirstOrDefault(c => MatchesRequest(c, normalizedRequest));
        if (exact != null && TryFile(exact, out var exactStream))
        {
            _logger.LogDebug(
                "Cache hit for song {SongId}: returning requested cached variant format={Format} maxBitRate={BitRate}.",
                songId,
                normalizedRequest.Format,
                normalizedRequest.MaxBitRate
            );
            return exactStream;
        }

        if (acceptAnyCached && !HasSpecificVariantRequest(normalizedRequest))
        {
            foreach (var cachedSong in cachedResults.Where(c => !c.IsOriginal))
            {
                if (TryFile(cachedSong, out var stream))
                {
                    _logger.LogDebug(
                        "Cache fallback hit for song {SongId}: returning cached variant format={Format} bitrate={Bitrate}.",
                        songId,
                        cachedSong.Format,
                        cachedSong.Bitrate
                    );
                    return stream;
                }
            }
        }

        _logger.LogDebug(
            "Cache miss for song {SongId}: requesting live stream format={Format} maxBitRate={BitRate} original={Original}.",
            songId,
            normalizedRequest.Format,
            normalizedRequest.MaxBitRate,
            IsOriginalRequest(normalizedRequest)
        );
        return await FetchAndCacheSongAsync(songId, normalizedRequest, dbContext, cancellationToken);
    }

    public async Task<Stream> CacheDownloadedSongAsync(
        string songId,
        Stream stream,
        SongRequest? request = null,
        CancellationToken cancellationToken = default
    )
    {
        using var dbContext = _dataContextFactory.CreateDbContext();
        _logger.LogDebug(
            "Caching externally downloaded song {SongId} with requested format={Format} maxBitRate={BitRate}.",
            songId,
            request?.Format,
            request?.MaxBitRate
        );
        return await CacheSongAsync(songId, stream, NormalizeRequest(request), dbContext, cancellationToken);
    }

    private async Task<List<DbCachedSong>> GetCachedSongsForIdAsync(
        string songId,
        BaseDataContext dbContext,
        CancellationToken cancellationToken
    )
    {
        return await dbContext.CachedSongs
            .Where(c => c.ParentItem.Id == songId)
            .ToListAsync(cancellationToken);
    }

    private bool TryFile(DbCachedSong cachedSong, out Stream stream)
    {
        _logger.LogDebug(
            "Trying cached song file {Filename} for {SongId} (original={Original}, bitrate={Bitrate})",
            cachedSong.Filename,
            cachedSong.ParentItem.Id,
            cachedSong.IsOriginal,
            cachedSong.Bitrate
        );

        try
        {
            stream = _storageManager.OpenSongFile(cachedSong.Filename);
            if (stream.Length == 0)
            {
                stream.Dispose();
                return FailAndDeleteEntry(cachedSong, out stream);
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            return FailAndDeleteEntry(cachedSong, out stream);
        }
    }

    private bool FailAndDeleteEntry(DbCachedSong cachedSong, out Stream stream)
    {
        using var dbContext = _dataContextFactory.CreateDbContext();
        var existing = dbContext.CachedSongs.SingleOrDefault(c => c.Id == cachedSong.Id);
        if (existing != null)
        {
            _logger.LogWarning(
                "Removing stale cached song entry {CacheId} for song {SongId}; file {Filename} was unavailable or empty.",
                existing.Id,
                existing.ParentItem.Id,
                existing.Filename
            );
            dbContext.CachedSongs.Remove(existing);
            dbContext.SaveChanges();
        }
        stream = null!;
        return false;
    }

    private async Task<Stream> FetchAndCacheSongAsync(
        string songId,
        SongRequest request,
        BaseDataContext dbContext,
        CancellationToken cancellationToken
    )
    {
        await LiveSongThrottle.WaitAsync(cancellationToken);
        try
        {
            var stream = await _liveSongService.GetSongAsync(songId, request, cancellationToken);
            return await CacheSongAsync(songId, stream, request, dbContext, cancellationToken);
        }
        finally
        {
            LiveSongThrottle.Release();
        }
    }

    private async Task<Stream> CacheSongAsync(
        string songId,
        Stream stream,
        SongRequest request,
        BaseDataContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var songParent = dbContext.Songs.Local.FirstOrDefault(s => s.Id == songId)
            ?? await dbContext.Songs.SingleOrDefaultAsync(s => s.Id == songId, cancellationToken);

        if (songParent is null)
        {
            throw new InvalidOperationException($"Song {songId} was not found in the local database.");
        }

        var id = Guid.NewGuid();
        var filename = GenerateFilename(id, request);

        _storageManager.SaveSongFile(filename, stream);
        _logger.LogDebug(
            "Saved cached song file for {SongId}: {Filename} (requested format={Format}, maxBitRate={BitRate}, original={Original}).",
            songId,
            filename,
            request.Format,
            request.MaxBitRate,
            IsOriginalRequest(request)
        );

        var cachedSong = new DbCachedSong
        {
            Id = id,
            Filename = filename,
            Format = GetStoredFormat(request),
            ParentItem = songParent,
            IsOriginal = IsOriginalRequest(request),
            // We key transcode cache variants by requested max bitrate and format.
            Bitrate = request.MaxBitRate ?? 0,
            Filesize = stream.CanSeek ? Convert.ToInt32(Math.Min(stream.Length, int.MaxValue)) : 0
        };

        cachedSong.AddDefaultCacheables(SongCacheExpiryMins);
        dbContext.CachedSongs.Add(cachedSong);
        await dbContext.SaveChangesAsync(cancellationToken);
        _logger.LogDebug(
            "Cached song metadata persisted for {SongId}: cacheId={CacheId}, format={Format}, bitrate={BitRate}.",
            songId,
            cachedSong.Id,
            cachedSong.Format,
            cachedSong.Bitrate
        );

        if (stream.CanSeek)
        {
            stream.Seek(0, SeekOrigin.Begin);
        }

        return stream;
    }

    private static bool MatchesRequest(DbCachedSong cachedSong, SongRequest request)
    {
        if (IsOriginalRequest(request))
        {
            return cachedSong.IsOriginal;
        }

        if (cachedSong.IsOriginal)
        {
            return false;
        }

        var requestedFormat = request.Format;
        var cachedFormat = cachedSong.Format;
        var formatMatches = requestedFormat == null || string.Equals(requestedFormat, cachedFormat, StringComparison.OrdinalIgnoreCase);
        var bitrateMatches = !request.MaxBitRate.HasValue || cachedSong.Bitrate >= request.MaxBitRate.Value;

        return formatMatches && bitrateMatches;
    }

    private static string GenerateFilename(Guid id, SongRequest request)
    {
        return $"{id:N}.wss";
    }

    private static bool HasSpecificVariantRequest(SongRequest request)
    {
        return !IsOriginalRequest(request) && (!string.IsNullOrWhiteSpace(request.Format) || request.MaxBitRate.HasValue);
    }

    private static SongRequest NormalizeRequest(SongRequest? request)
    {
        var format = request?.Format?.Trim();
        return new SongRequest
        {
            RequestOriginalSource = request?.RequestOriginalSource ?? false,
            Format = string.IsNullOrWhiteSpace(format) ? null : format.ToLowerInvariant(),
            MaxBitRate = request?.MaxBitRate
        };
    }

    private static bool IsOriginalRequest(SongRequest request)
    {
        return request.RequestOriginalSource || string.Equals(request.Format, "raw", StringComparison.OrdinalIgnoreCase);
    }

    private static string GetStoredFormat(SongRequest request)
    {
        if (IsOriginalRequest(request))
        {
            return "raw";
        }

        return request.Format ?? "unknown";
    }
}
