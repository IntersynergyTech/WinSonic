using Microsoft.EntityFrameworkCore;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.DbModels;
using WinSonic.Data.DbModels.LocalCacheEntries;
using WinSonic.Data.Utilities;

namespace WinSonic.Service.Artwork;

// I HATE FILES

public class CachedArtworkService : IArtworkService
{
    private readonly StorageManager _storageManager;
    private readonly BaseDataContext _dataContext;
    private readonly LiveArtworkService _liveArtworkService;
    private const int ArtworkCacheExpiryMins = 525600; // 1 year in minutes

    public CachedArtworkService(
        StorageManager storageManager,
        BaseDataContext dataContext,
        LiveArtworkService liveArtworkService
    )
    {
        _storageManager = storageManager;
        _dataContext = dataContext;
        _liveArtworkService = liveArtworkService;
    }

    public async Task<Stream> GetArtworkAsync(
        string coverArtId,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        Console.WriteLine($"Getting artwork for {coverArtId} with acceptAnyCached={acceptAnyCached}");
        var cachedResults = await GetArtCachesForIdAsync(coverArtId);
        var original = cachedResults.FirstOrDefault(c => c.Dimension == null);

        if (original != null && TryFile(original, out var originalStream))
        {
            return originalStream;
        }

        if (acceptAnyCached && cachedResults.Any())
        {
            var orderedCached = cachedResults.Where(c => c.Dimension.HasValue)
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

        //atp we've either ran out of cached entries and/or aren't accepting others, so fetch from the live service and cache it.
        var result = await FetchAndCacheArtworkAsync(coverArtId, null, cancellationToken);
        return result;
    }

    public Task<Stream> GetArtworkWithDimensionAsync(
        string coverArtId,
        int dimension,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }

    private async Task<List<CachedCoverArt>> GetArtCachesForIdAsync(string artworkId)
    {
        var cachedResults = await _dataContext.CachedCoverArt.Where(c => c.ParentItem.Id == artworkId).ToListAsync();
        return cachedResults;
    }

    private bool TryFile(CachedCoverArt art, out Stream stream)
    {
        Console.WriteLine($"Trying file for {art.Filename} {art.Id} dim {art.Dimension} parent {art.ParentItem.Id}");

        try
        {
            stream = _storageManager.OpenArtworkFile(art.Filename);

            if (stream.Length == 0)
            {
                stream.Close();
                return Fail(out stream);
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            return Fail(out stream);
        }

        bool Fail(out Stream stream)
        {
            _dataContext.CachedCoverArt.Remove(art);
            _dataContext.SaveChanges();
            stream = null;
            return false;
        }
    }

    private async Task<Stream> FetchAndCacheArtworkAsync(
        string coverArtId,
        int? dimension,
        CancellationToken cancellationToken
    )
    {
        Stream stream;

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

        if (stream != null)
        {
            var id = Guid.NewGuid();

            var filename = GenerateFilename(id, dimension);
            _storageManager.SaveArtworkFile(filename, stream);

            var coverArtParent = _dataContext.CoverArt.Local.FirstOrDefault(c => c.Id == coverArtId)
                ?? new CoverArt(coverArtId);

            var cachedCoverArt = new CachedCoverArt
            {
                ParentItem = coverArtParent,
                Dimension = dimension,
                Filename = filename,
                Id = id
            };

            cachedCoverArt.AddDefaultCacheables(ArtworkCacheExpiryMins);

            _dataContext.CachedCoverArt.Add(cachedCoverArt);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        if (stream.CanSeek)
        {
            //Reset stream back to the beginning if we just downloaded otherwise skia dies
            stream.Seek(0, SeekOrigin.Begin);
        }

        return stream;
    }

    private string GenerateFilename(Guid id, int? dimension)
    {
        return dimension.HasValue ? $"{id}_{dimension.Value}.jpg" : $"{id}.jpg";
    }
}
