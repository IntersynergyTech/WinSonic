namespace WinSonic.Service.History;

public interface IPlaybackHistoryService
{
    /// <summary>
    /// Scrobble a song that has been completed playing.
    /// </summary>
    /// <param name="song">The song to scrobble.</param>
    /// <param name="time">The time the song **STARTED** playing</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task ScrobbleCompleted(Core.Models.Song song, DateTime? time = null, CancellationToken cancellationToken = default);
    public Task ScrobbleNowPlaying(Core.Models.Song song, CancellationToken cancellationToken = default);
    
}
