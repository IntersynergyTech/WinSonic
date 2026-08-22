using Microsoft.Extensions.Logging;
using WinSonic.Core;
using WinSonic.Data;
using WinSonic.Data.DbModels;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Service.Artwork;

public class LiveArtworkService : IArtworkService
{
    private readonly SubsonicApiWrapper _api;
    private readonly ILogger<LiveArtworkService> _logger;

    public LiveArtworkService(
        SubsonicApiWrapper api,
        ILogger<LiveArtworkService> logger
    )
    {
        _api = api;
        _logger = logger;
    }

    public async Task<Stream> GetArtworkAsync(
        string coverArtId,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        _logger.LogDebug($"Fetching Live artwork for CoverArtId: {coverArtId}");
        var api = _api.MediaRetrieval;
        var result = api.GetCoverArtWithHttpInfo(coverArtId);
        _logger.LogDebug($"Artwork secured for CoverArtId: {coverArtId} - StatusCode: {result.StatusCode}");
        return result.Data;
    }

    public async Task<Stream> GetArtworkWithDimensionAsync(
        string coverArtId,
        int dimension,
        bool acceptAnyCached,
        CancellationToken cancellationToken = default
    )
    {
        _logger.LogDebug($"Fetching Live artwork for CoverArtId: {coverArtId} with Dimension: {dimension}");
        var api = _api.MediaRetrieval;
        var artwork = await api.GetCoverArtAsync(coverArtId, dimension, cancellationToken: cancellationToken);
        _logger.LogDebug($"Artwork secured for CoverArtId: {coverArtId} with Dimension: {dimension}");
        return artwork;
    }
}
