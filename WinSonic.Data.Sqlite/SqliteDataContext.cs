using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WinSonic.Data.Sqlite;

public class SqliteDataContext : BaseDataContext
{
    private readonly string _dbFileName;

    public SqliteDataContext(string sqliteFileName)
    {
        _dbFileName = sqliteFileName;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new DbConnectionStringBuilder();
        builder.Add("Data Source", _dbFileName);

        var connectionString = builder.ConnectionString;

        optionsBuilder.UseSqlite(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}
