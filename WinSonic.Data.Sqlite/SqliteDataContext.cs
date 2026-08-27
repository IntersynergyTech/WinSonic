using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WinSonic.Data.Sqlite;

public class SqliteDataContext : BaseDataContext
{
    private readonly string _dbFileName;
    private readonly ILogger<SqliteDataContext> _logger;

    public SqliteDataContext(string sqliteFileName, ILogger<SqliteDataContext> logger)
    {
        _dbFileName = sqliteFileName;
        _logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new DbConnectionStringBuilder();
        builder.Add("Data Source", _dbFileName);

        var connectionString = builder.ConnectionString;

        optionsBuilder.UseSqlite(connectionString);

#if DEBUG
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        //optionsBuilder.LogTo(message => _logger.LogTrace(message), LogLevel.Information);
#endif

        base.OnConfiguring(optionsBuilder);
    }
}
