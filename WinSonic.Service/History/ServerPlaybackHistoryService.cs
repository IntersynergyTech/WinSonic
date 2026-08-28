using Microsoft.Extensions.Logging;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Service.History;

public class ServerPlaybackHistoryService : IPlaybackHistoryService
{
    private readonly SubsonicApiWrapper _api;
    private readonly ILogger<ServerPlaybackHistoryService> _logger;

    public ServerPlaybackHistoryService(SubsonicApiWrapper api, ILogger<ServerPlaybackHistoryService> logger)
    {
        _api = api;
        _logger = logger;
    }

    public async Task ScrobbleCompleted(
        Core.Models.Song song,
        DateTime? time = null,
        CancellationToken cancellationToken = default
    )
    {
        var scrobbleResult = await _api.MediaAnnotation.ScrobbleAsync(
            song.Id,
            TimeToMillsecondsSince1970(time ?? DateTime.UtcNow),
            submission: true,
            cancellationToken: cancellationToken
        );

        if (scrobbleResult.VarSubsonicResponse.GetSubsonicSuccessResponse().Status
            == SubsonicSuccessResponse.StatusEnum.Ok)
        {
            _logger.LogDebug($"Scrobbled completed track to server: {song.Title}");
        }
    }

    long TimeToMillsecondsSince1970(DateTime time)
    {
        var utcTime = time.ToUniversalTime();
        var unixTimestamp = (long)(utcTime.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        return unixTimestamp;
    }

    public Task ScrobbleNowPlaying(
        Core.Models.Song song,
        CancellationToken cancellationToken = default
    )
    {
        return _api.MediaAnnotation.ScrobbleAsync(
            song.Id,
            null,
            submission: false,
            cancellationToken: cancellationToken
        );
    }

}
