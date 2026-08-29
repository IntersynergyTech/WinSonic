using Microsoft.Extensions.Logging;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Service.Song;

public class LiveSongService
{
    private readonly SubsonicApiWrapper _api;
    private readonly ILogger<LiveSongService> _logger;

    public LiveSongService(
        SubsonicApiWrapper api,
        ILogger<LiveSongService> logger
    )
    {
        _api = api;
        _logger = logger;
    }

    public Task<Stream> GetSongAsync(
        string songId,
        SongRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var normalizedRequest = NormalizeRequest(request);
        var requestingOriginal = IsOriginalRequest(normalizedRequest);
        var requestedFormat = requestingOriginal ? "raw" : normalizedRequest.Format;
        var requestedBitRate = requestingOriginal ? null : normalizedRequest.MaxBitRate;

        _logger.LogDebug(
            "Fetching live song {SongId} with format={Format}, maxBitRate={BitRate}, original={Original}",
            songId,
            requestedFormat,
            requestedBitRate,
            requestingOriginal
        );

        var response = _api.MediaRetrieval.StreamWithHttpInfo(
            songId,
            maxBitRate: requestedBitRate,
            format: requestedFormat
        );

        _logger.LogDebug(
            "Live song stream acquired for {SongId}: status={StatusCode}, format={Format}, maxBitRate={BitRate}.",
            songId,
            response.StatusCode,
            requestedFormat,
            requestedBitRate
        );

        return Task.FromResult(response.Data);
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
}
