using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WinSonic.Core;

namespace WinSonic.Data.Sqlite;

public class SqliteDataContextFactory : IDbContextFactory<BaseDataContext>
{
    private readonly ILogger<SqliteDataContextFactory> _logger;
    private readonly StorageManager _storageManager;
    private readonly string _dbFileName;
    private bool hasUpdated = false;

    public SqliteDataContextFactory(StorageManager storageManager, ILogger<SqliteDataContextFactory> logger)
    {
        _storageManager = storageManager;
        _dbFileName = _storageManager.GetDatabaseFile();
        _logger = logger;
        
        _logger.LogInformation("Initialising DB...");
        var context = Create();
        _logger.LogInformation($"Database active: {context.Database.CanConnect()}");
    }

    public SqliteDataContext Create()
    {
        var context = new SqliteDataContext(_dbFileName);

        if (!hasUpdated)
        {
            hasUpdated = true;
            context.UpdateMigrationState(_logger);
        }

        return context;
    }

    public BaseDataContext CreateDbContext()
    {
        return Create();
    }
}
