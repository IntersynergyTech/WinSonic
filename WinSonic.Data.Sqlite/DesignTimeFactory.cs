using Microsoft.EntityFrameworkCore.Design;
using WinSonic.Core;

namespace WinSonic.Data.Sqlite;

public class DesignTimeFactory : IDesignTimeDbContextFactory<SqliteDataContext>
{
    public SqliteDataContext CreateDbContext(string[] args)
    {
        return new SqliteDataContext(new StorageManager().GetDatabaseFile());
    }
}
