using WinSonic.Data.Sqlite;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync;

public class SyncManager
{
    private readonly SubsonicApiWrapper _api;
    private readonly SqliteDataContextFactory _dbFactory;

    public static int DefaultCacheExpiryMins = 10080; // 7 days 

    private readonly BigSync _bigSync;

    public SyncManager(SubsonicApiWrapper api, SqliteDataContextFactory dbFactory)
    {
        _api = api;
        _dbFactory = dbFactory;

        _bigSync = new BigSync(dbFactory, _api);
    }

    private CancellationTokenSource? _bigSyncCancellationToken;

    private void Log(string message)
    {
        Console.WriteLine($"[SYNC]: {message}");
    }

    public void StartBigSync()
    {
        Log("Requesting Big Sync");
        _bigSyncCancellationToken = new CancellationTokenSource();
        Task.Run(() => _bigSync.RunBigSync(_bigSyncCancellationToken.Token));
    }

    public async Task CancelAll()
    {
        if (_bigSync.IsRunning)
        {
            await _bigSyncCancellationToken!.CancelAsync();
        }
    }
}
