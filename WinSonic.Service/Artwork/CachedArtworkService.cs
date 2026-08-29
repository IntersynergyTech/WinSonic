using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.DbModels;
using WinSonic.Data.DbModels.LocalCacheEntries;
using WinSonic.Data.Utilities;
using WinSonic.Service.Misc;

namespace WinSonic.Service.Artwork;

// I HATE FILES

public class CachedArtworkService : IArtworkService
{
    private readonly StorageManager _storageManager;
    private readonly IDbContextFactory<BaseDataContext> _dataContextFactory;
    private readonly LiveArtworkService _liveArtworkService;
    private readonly IImageResizer _imageResizer;
    private readonly ILogger<CachedArtworkService> _logger;
    private const int ArtworkCacheExpiryMins = 525600; // 1 year in minutes

    private const int MaxConcurrentFullArtworkRequests = 8;
    private const int MaxConcurrentLiveArtworkRequests = 4;

    private static readonly SemaphoreSlim LiveArtworkThrottle = new(MaxConcurrentLiveArtworkRequests, MaxConcurrentLiveArtworkRequests);
    private static readonly SemaphoreSlim FullArtworkThrottle = new(MaxConcurrentFullArtworkRequests, MaxConcurrentFullArtworkRequests);

    public CachedArtworkService(
        StorageManager storageManager,
        IDbContextFactory<BaseDataContext> dataContextFactory,
        LiveArtworkService liveArtworkService,
        IImageResizer imageResizer,
        ILogger<CachedArtworkService> logger
    )
    {
        _storageManager = storageManager;
        _dataContextFactory = dataContextFactory;
        _liveArtworkService = liveArtworkService;
        _imageResizer = imageResizer;
        _logger = logger;
    }

    public async Task<Stream> GetArtworkAsync(
        string coverArtId,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        var dbContext = _dataContextFactory.CreateDbContext();

        var cachedResults = await GetArtCachesForIdAsync(coverArtId, dbContext);

        return await GetFullArtworkInternalAsync(
            coverArtId,
            acceptAnyCached,
            cachedResults,
            dbContext,
            cancellationToken
        );
    }

    private async Task<Stream> GetFullArtworkInternalAsync(
        string coverArtId,
        bool acceptAnyCached,
        List<DbCachedCoverArt> cachedResults,
        BaseDataContext? dbContext = null,
        CancellationToken cancellationToken = default
    )
    {
        // Spamming the filesystem for full artworks was a bit nasty too
        await FullArtworkThrottle.WaitAsync(cancellationToken);
        try
        {
            var result = await GetArtworkInternalAsync(
                coverArtId,
                acceptAnyCached,
                cancellationToken,
                cachedResults,
                null
            );

            if (result != null)
            {
                return result;
            }

            //atp we've either ran out of cached entries and/or aren't accepting others, so fetch from the live service and cache it.
            var finalResult = await FetchAndCacheArtworkAsync(coverArtId, null, cancellationToken, dbContext);
            return finalResult;
        }
        finally
        {
            FullArtworkThrottle.Release();
        }
    }

    public async Task<Stream> GetArtworkWithDimensionAsync(
        string coverArtId,
        int dimension,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        var dbContext = _dataContextFactory.CreateDbContext();

        var cachedResults = await GetArtCachesForIdAsync(coverArtId, dbContext);

        var result = await GetArtworkInternalAsync(
            coverArtId,
            acceptAnyCached,
            cancellationToken,
            cachedResults,
            dimension
        );

        if (result != null)
        {
            return result;
        }

        // At this point it's just that we don't have a cached entry for the requested dimension, but we might have an original and we can resize ourselves, rather than asking the server for a resize. And that'll just ask the server for the original and we cache it if it's not there.
        var original = await GetFullArtworkInternalAsync(
            coverArtId,
            acceptAnyCached: false,
            cachedResults,
            dbContext,
            cancellationToken
        );

        if (original != null)
        {
            var resizedStream = _imageResizer.ResizeImage(original, dimension, dimension, maintainAspectRatio: true);

            var cachedResizedResult = await CacheArtworkAsync(
                coverArtId,
                dimension,
                resizedStream,
                cancellationToken,
                dbContext
            );

            return cachedResizedResult;
        }

        // In theory this should never happen because the above resize should always pull something.
        var fetchedResult = await FetchAndCacheArtworkAsync(coverArtId, dimension, cancellationToken, dbContext);
        return fetchedResult;
    }

    private async Task<Stream?> GetArtworkInternalAsync(
        string coverArtId,
        bool acceptAnyCached,
        CancellationToken cancellationToken,
        List<DbCachedCoverArt> cachedResults,
        int? dimension
    )
    {
        _logger.LogDebug("Getting artwork for {coverArtId} with acceptAnyCached={acceptAnyCached} with dimension={dimension}. Cached results: {cachedResultsCount}", coverArtId, acceptAnyCached, dimension, cachedResults.Count);

        var exact = cachedResults.FirstOrDefault(c => c.Dimension == dimension);

        if (exact != null && TryFile(exact, out var originalStream))
        {
            return originalStream;
        }

        if (acceptAnyCached && cachedResults.Any())
        {
            var orderedCached = cachedResults.Where(c => c.Dimension.HasValue)
                .Where(c => dimension == null || c.Dimension >= dimension)
                .OrderByDescending(c => c.Dimension ?? 0)
                .ToList();

            foreach (var cachedCoverArt in orderedCached)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return await Task.FromCanceled<Stream>(cancellationToken);
                }

                if (TryFile(cachedCoverArt, out var stream))
                {
                    return stream;
                }
            }
        }

        return null;
    }

    private async Task<List<DbCachedCoverArt>> GetArtCachesForIdAsync(string artworkId, BaseDataContext dataContext)
    {
        var cachedResults = await dataContext.CachedCoverArt.Where(c => c.ParentItem.Id == artworkId).ToListAsync();
        return cachedResults;
    }

    private bool TryFile(DbCachedCoverArt art, out Stream stream)
    {
        _logger.LogDebug("Trying file for {filename} {artId} dim {dimension} parent {parentId}", art.Filename, art.Id, art.Dimension, art.ParentItem.Id);    

        try
        {
            stream = _storageManager.OpenArtworkFile(art.Filename);

            if (stream.Length == 0)
            {
                _logger.LogWarning("File is empty for {filename} {artId} dim {dimension} parent {parentId}", art.Filename, art.Id, art.Dimension, art.ParentItem.Id);
                stream.Close();
                return Fail(out stream);
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            _logger.LogWarning("File not found for {filename} {artId} dim {dimension} parent {parentId}", art.Filename, art.Id, art.Dimension, art.ParentItem.Id);
            return Fail(out stream);
        }

        bool Fail(out Stream stream)
        {
            using var dataContext = _dataContextFactory.CreateDbContext();
            dataContext.CachedCoverArt.Remove(art);
            dataContext.SaveChanges();
            stream = null;
            return false;
        }
    }

    private async Task<Stream> FetchAndCacheArtworkAsync(
        string coverArtId,
        int? dimension,
        CancellationToken cancellationToken,
        BaseDataContext dataContext
    )
    {
        Stream stream;

        // We were getting stuck for ages because spamming the server for a zillion artworks when the user is scrolling through the play queue was pain
        await LiveArtworkThrottle.WaitAsync(cancellationToken);
        try
        {
            //LAS doesn't actually care what we send for AcceptAnyCached because it never uses the cache anyway, so it doesn't really matter what we say.
            if (dimension.HasValue)
            {
                stream = await _liveArtworkService.GetArtworkWithDimensionAsync(
                    coverArtId,
                    dimension.Value,
                    false,
                    cancellationToken: cancellationToken
                );
            }
            else
            {
                stream = await _liveArtworkService.GetArtworkAsync(coverArtId, false, cancellationToken: cancellationToken);
            }
        }
        finally
        {
            LiveArtworkThrottle.Release();
        }

        await CacheArtworkAsync(
            coverArtId,
            dimension,
            stream,
            cancellationToken,
            dataContext
        );

        return stream;
    }

    private async Task<Stream> CacheArtworkAsync(
        string coverArtId,
        int? dimension,
        Stream stream,
        CancellationToken cancellationToken,
        BaseDataContext dataContext
    )
    {
        if (stream != null)
        {
            var id = Guid.NewGuid();

            var filename = GenerateFilename(id, dimension);
            _storageManager.SaveArtworkFile(filename, stream);

            var coverArtParent = dataContext.CoverArt.Local.FirstOrDefault(c => c.Id == coverArtId);

            if (coverArtParent is null)
            {
                coverArtParent = new DbCoverArt(coverArtId);
                dataContext.Attach(coverArtParent);
            }

            var cachedCoverArt = new DbCachedCoverArt
            {
                ParentItem = coverArtParent,
                Dimension = dimension,
                Filename = filename,
                Id = id
            };

            cachedCoverArt.AddDefaultCacheables(ArtworkCacheExpiryMins);

            dataContext.CachedCoverArt.Add(cachedCoverArt);
            await dataContext.SaveChangesAsync(cancellationToken);

            if (stream.CanSeek)
            {
                //Reset stream back to the beginning if we just downloaded otherwise skia dies
                stream.Seek(0, SeekOrigin.Begin);
            }
        }

        return stream;
    }

    private string GenerateFilename(Guid id, int? dimension)
    {
        return dimension.HasValue ? $"{id}_{dimension.Value}.jpg" : $"{id}.jpg";
    }
}
