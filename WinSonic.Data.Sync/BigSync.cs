using WinSonic.Data.Sqlite;
using WinSonic.Data.Sync.SyncTasks;
using WinSonic.Subsonic.Client.Model;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync;

public class BigSync
{
    private readonly SqliteDataContextFactory _databaseFactory;
    private readonly SubsonicApiWrapper _api;
    private BaseDataContext _database;
    private const int ITEMS_PER_REQUEST = 100;

    public BigSync(SqliteDataContextFactory databaseFactory, SubsonicApiWrapper api)
    {
        _databaseFactory = databaseFactory;
        _api = api;
    }

    public void RunBigSync(CancellationToken cancellationToken)
    {
        IsRunning = true;
        Log("Checking Syncability");
        _database = _databaseFactory.Create();
        var dbConnect = _database.Database.CanConnect();
        var apiConnect = _api.IsAvailable();
        Log($"Syncability: API Available: {apiConnect} DB Available: {dbConnect}");
        RunBigSyncInternal(cancellationToken);
        IsRunning = false;
    }

    private void Log(string message)
    {
        Console.WriteLine($"[BIGSYNC]: {message}");
    }

    private void RunBigSyncInternal(CancellationToken cancellationToken)
    {
        Log($"Getting Artists");
        BigSyncArtists.SyncArtists(cancellationToken, ITEMS_PER_REQUEST, _api, _database);

        Log($"Getting Albums");
        BigSyncAlbums.SyncAlbums(cancellationToken, ITEMS_PER_REQUEST, _api, _database);

        Log($"Getting songs...");
        BigSyncSongs.SyncSongs(cancellationToken, ITEMS_PER_REQUEST, _api, _database);
        
        Log($"Getting playlists...");
        BigSyncPlaylists.SyncPlaylists(cancellationToken, ITEMS_PER_REQUEST, _api, _database);
        
        Log("Finishing up.");
    }

    public bool IsRunning { get; set; }
}
