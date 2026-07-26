using Microsoft.EntityFrameworkCore;
using WinSonic.Data.DbModels;
using WinSonic.Data.DbModels.LocalCacheEntries;

namespace WinSonic.Data;

public class BaseDataContext : DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumMedia> AlbumMedia { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<CoverArt> CoverArt { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }

    public DbSet<CachedCoverArt> CachedCoverArt { get; set; }
    public DbSet<CachedSong> CachedSongs { get; set; }

    public void UpdateMigrationState()
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }
}
