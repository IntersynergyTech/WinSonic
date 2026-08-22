namespace WinSonic.Service.History;

public interface IPlaybackHistoryService
{
    public Task ScrobbleCompleted(Core.Models.Song song, DateTime? time = null, CancellationToken cancellationToken = default);
    public Task ScrobbleNowPlaying(Core.Models.Song song, CancellationToken cancellationToken = default);
    
}
