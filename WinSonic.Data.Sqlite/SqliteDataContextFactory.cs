using WinSonic.Core;

namespace WinSonic.Data.Sqlite;

public class SqliteDataContextFactory
{
    private readonly StorageManager _storageManager;
    private readonly string _dbFileName;
    private bool hasUpdated = false;

    public SqliteDataContextFactory(StorageManager storageManager)
    {
        _storageManager = storageManager;
        _dbFileName = _storageManager.GetDatabaseFile();
        
        Console.WriteLine("Initialising DB...");
        var context = Create();
        Console.WriteLine($"Database active: {context.Database.CanConnect()}");
    }

    public SqliteDataContext Create()
    {
        var context = new SqliteDataContext(_dbFileName);

        if (!hasUpdated)
        {
            hasUpdated = true;
            context.UpdateMigrationState();
        }

        return context;
    }
}
