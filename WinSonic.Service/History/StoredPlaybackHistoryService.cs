using Microsoft.Extensions.Logging;
using WinSonic.Data;
using WinSonic.Data.DbModels;

namespace WinSonic.Service.History;

public class StoredPlaybackHistoryService : IPlaybackHistoryService
{
    public StoredPlaybackHistoryService(
        BaseDataContext database,
        ServerPlaybackHistoryService serverHistoryService,
        ILogger<StoredPlaybackHistoryService> logger
    )
    {
        _database = database;
        _serverHistoryService = serverHistoryService;
        _logger = logger;
    }

    private readonly BaseDataContext _database;
    private readonly ServerPlaybackHistoryService _serverHistoryService;
    private readonly ILogger<StoredPlaybackHistoryService> _logger;

    private DbPlayHistoryEntry? _lastNowPlayingEntry;

    public async Task ScrobbleCompleted(
        Core.Models.Song song,
        DateTime? time = null,
        CancellationToken cancellationToken = default
    )
    {
        var dbSong = _database.Songs.Find(song.Id);
        var scrobbleTime = time ?? DateTime.UtcNow;

        var entry = new DbPlayHistoryEntry
        {
            Song = dbSong!, 
            PlayedAt = scrobbleTime, 
            Scrobbled = false
        };

        try
        {
            await _serverHistoryService.ScrobbleCompleted(song, scrobbleTime, cancellationToken);
            entry.Scrobbled = true;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Error scrobbling completed track to server (it will be deferred): {Message}", e.Message);
            // ndb if it fails, we just store it locally and try again later
        }

        _database.PlayHistory.Add(entry);
        await _database.SaveChangesAsync(cancellationToken);
    }

    public Task ScrobbleNowPlaying(Core.Models.Song song, CancellationToken cancellationToken = default)
    {
        // We dont' store live now playing so just send it to the server and swallow if it's not available.
        try
        {
            return _serverHistoryService.ScrobbleNowPlaying(song, cancellationToken);
        }
        catch (Exception ex)
        {
            // Log the error and swallow it
            _logger.LogWarning(ex, $"Swallowed Error scrobbling now playing track: {ex.Message}");
            return Task.CompletedTask;
        }
    }
}
