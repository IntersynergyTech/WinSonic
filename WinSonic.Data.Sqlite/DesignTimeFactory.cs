using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using WinSonic.Core;

namespace WinSonic.Data.Sqlite;

public class DesignTimeFactory : IDesignTimeDbContextFactory<SqliteDataContext>
{
    public SqliteDataContext CreateDbContext(string[] args)
    {
        return new SqliteDataContext(new StorageManager().GetDatabaseFile(), new DesignDummyLogger());
    }

    public class DesignDummyLogger : ILogger<SqliteDataContext>
    {
        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter
        )
        {
            
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {   
            
            return null;
        }
    }
}


