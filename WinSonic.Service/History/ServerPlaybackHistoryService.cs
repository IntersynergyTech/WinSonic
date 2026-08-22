using WinSonic.Subsonic.Helpers;

namespace WinSonic.Service.History;

public class ServerPlaybackHistoryService : IPlaybackHistoryService
{
    private readonly SubsonicApiWrapper _api;


    public ServerPlaybackHistoryService(SubsonicApiWrapper api)
    {
        _api = api;
    }

    public Task ScrobbleCompleted(
        Core.Models.Song song,
        DateTime? time = null,
        CancellationToken cancellationToken = default
    )
    {
        return _api.MediaAnnotation.ScrobbleAsync(
            song.Id,
            TimeToUtcTimestamp(time ?? DateTime.Now),
            submission: true,
            cancellationToken: cancellationToken
        );
        throw new NotImplementedException();
    }

    int TimeToUtcTimestamp(DateTime time)
    {
        var utcTime = time.ToUniversalTime();
        var unixTimestamp = (int)(utcTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
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
