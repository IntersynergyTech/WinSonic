using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Data;
using WinSonic.Subsonic.Helpers;

namespace WinSonic.Data.Sync;

public class SyncManager
{
    private readonly SubsonicApiWrapper _api;
    private readonly IDbContextFactory<BaseDataContext> _dbFactory;
    private readonly ILogger<SyncManager> _logger;

    public static int DefaultCacheExpiryMins = 10080; // 7 days

    private readonly BigSync _bigSync;

    public SyncManager(SubsonicApiWrapper api, IDbContextFactory<BaseDataContext> dbFactory, ILogger<SyncManager> logger, ILoggerFactory loggerFactory)
    {
        _api = api;
        _dbFactory = dbFactory;
        _logger = logger;

        var syncLogger = loggerFactory.CreateLogger<BigSync>();

        _bigSync = new BigSync(dbFactory, api, syncLogger);
    }

    private CancellationTokenSource? _bigSyncCancellationToken;

    private void Log(string message)
    {
        _logger.LogInformation(message);
    }

    public Task StartBigSyncAsync()
    {
        Log("Requesting Big Sync");
        _bigSyncCancellationToken = new CancellationTokenSource();
        return Task.Run(() => _bigSync.RunBigSync(_bigSyncCancellationToken.Token));
    }

    public void StartBigSync()
    {
        _ = StartBigSyncAsync();
    }

    public async Task CancelAll()
    {
        if (_bigSync.IsRunning)
        {
            await _bigSyncCancellationToken!.CancelAsync();
        }
    }
}
