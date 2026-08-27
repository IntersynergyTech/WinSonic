using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Data;
using WinSonic.Data.Sync.SyncTasks;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync;

public class BigSync
{
    private readonly IDbContextFactory<BaseDataContext> _databaseFactory;
    private readonly SubsonicApiWrapper _api;
    private readonly ILogger<BigSync> _logger;
    private BaseDataContext _database;
    private const int ITEMS_PER_REQUEST = 500;

    public BigSync(IDbContextFactory<BaseDataContext> databaseFactory, SubsonicApiWrapper api, ILogger<BigSync> logger)
    {
        _databaseFactory = databaseFactory;
        _api = api;
        _logger = logger;
    }

    public void RunBigSync(CancellationToken cancellationToken)
    {
        IsRunning = true;
        Log("Checking Syncability");
        _database = _databaseFactory.CreateDbContext();
        var dbConnect = _database.Database.CanConnect();
        var apiConnect = _api.IsAvailable();
        Log($"Syncability: API Available: {apiConnect} DB Available: {dbConnect}");
        RunBigSyncInternal(cancellationToken);
        IsRunning = false;
    }

    private void Log(string message)
    {
        _logger.LogInformation(message);
    }

    private void RunBigSyncInternal(CancellationToken cancellationToken)
    {
        Log($"Getting Artists");
        BigSyncArtists.SyncArtists(cancellationToken, ITEMS_PER_REQUEST, _api, _database, _logger); 

        Log($"Getting Albums");
        BigSyncAlbums.SyncAlbums(cancellationToken, ITEMS_PER_REQUEST, _api, _database, _logger);

        Log($"Getting songs...");
        BigSyncSongs.SyncSongs(cancellationToken, ITEMS_PER_REQUEST, _api, _database, _logger);
        
        Log($"Getting playlists...");
        BigSyncPlaylists.SyncPlaylists(cancellationToken, ITEMS_PER_REQUEST, _api, _database, _logger);
        
        Log("Finishing up.");
    }

    public bool IsRunning { get; set; }
}
