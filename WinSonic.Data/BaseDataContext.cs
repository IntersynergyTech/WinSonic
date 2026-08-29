using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using WinSonic.Data.DbModels;
using WinSonic.Data.DbModels.LocalCacheEntries;

namespace WinSonic.Data;

public class BaseDataContext : DbContext
{
    
    public DbSet<DbAlbum> Albums { get; set; }
    public DbSet<DbAlbumMedia> AlbumMedia { get; set; }
    public DbSet<DbArtist> Artists { get; set; }
    public DbSet<DbCoverArt> CoverArt { get; set; }
    public DbSet<DbPlaylist> Playlists { get; set; }
    public DbSet<DbSong> Songs { get; set; }
    public DbSet<DbPlayHistoryEntry> PlayHistory { get; set; }
    public DbSet<DbPlayQueueEntry> PlayQueue { get; set; }
    public DbSet<DbSettings> Settings { get; set; }

    public DbSet<DbCachedCoverArt> CachedCoverArt { get; set; }
    public DbSet<DbCachedSong> CachedSongs { get; set; }

    public void UpdateMigrationState(ILogger logger)
    {
        if (Database.GetPendingMigrations().Any())
        {
            if (Database.GetPendingMigrations().Any())
            {
                logger.LogWarning("Database model is out of date. Applying migrations now...");
                Database.Migrate();
                logger.LogWarning("Migrations applied.");
            }
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAlbum(modelBuilder.Entity<DbAlbum>());
        ConfigureArtist(modelBuilder.Entity<DbArtist>());
        ConfigureAlbumMedia(modelBuilder.Entity<DbAlbumMedia>());
        ConfigurePlaylist(modelBuilder.Entity<DbPlaylist>());
        ConfigureSong(modelBuilder.Entity<DbSong>());
        ConfigureCoverArt(modelBuilder.Entity<DbCoverArt>());
        ConfigureCachedCoverArt(modelBuilder.Entity<DbCachedCoverArt>());
        ConfigureCachedSong(modelBuilder.Entity<DbCachedSong>());
        ConfigurePlayHistory(modelBuilder.Entity<DbPlayHistoryEntry>());
        ConfigurePlayQueue(modelBuilder.Entity<DbPlayQueueEntry>());
        ConfigureSettings(modelBuilder.Entity<DbSettings>());
    }

    void ConfigureAlbum(EntityTypeBuilder<DbAlbum> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SortTitle).HasMaxLength(200);

        //builder.HasOne(a => a.Artist).WithMany(a => a.Albums);

        builder.HasOne(a => a.CoverArt)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Songs).WithOne(a => a.Album).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.Media).WithOne(a => a.Album).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.Artists).WithMany(a => a.Albums);
    }

    void ConfigureArtist(EntityTypeBuilder<DbArtist> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SortTitle).HasMaxLength(200);

        builder.HasOne(a => a.CoverArt)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Albums).WithMany(a => a.Artists);
        builder.HasMany(a => a.Songs).WithMany(a => a.Artists);
        builder.HasMany(a => a.SongsAsAlbumArtist).WithMany(a => a.AlbumArtists);
    }

    void ConfigurePlaylist(EntityTypeBuilder<DbPlaylist> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SongCount).IsRequired();

        builder.Property(a => a.Duration).IsRequired();

        builder.Property(a => a.CreatedAt).IsRequired();

        builder.Property(a => a.UpdatedAt).IsRequired();

        builder.HasOne(a => a.CoverArt)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Songs).WithMany(a => a.AppearsInPlaylists);
    }

    void ConfigureSong(EntityTypeBuilder<DbSong> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.HasOne(a => a.Album).WithMany(a => a.Songs).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.Artist).WithMany().OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.CoverArt).WithMany().OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Artists).WithMany(a => a.Songs).UsingEntity("SongToArtists");;
        builder.HasMany(a => a.AppearsInPlaylists).WithMany(a => a.Songs);
        
        builder.HasMany(a => a.AlbumArtists).WithMany(a => a.SongsAsAlbumArtist).UsingEntity("SongToAlbumArtists");

        builder.HasMany(a => a.LocalCacheEntries).WithOne(a => a.ParentItem).OnDelete(DeleteBehavior.Cascade);
    }
    
    void ConfigurePlayHistory(EntityTypeBuilder<DbPlayHistoryEntry> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Song)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    void ConfigurePlayQueue(EntityTypeBuilder<DbPlayQueueEntry> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Song)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }

    void ConfigureSettings(EntityTypeBuilder<DbSettings> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.LanguageIetf).IsRequired().HasMaxLength(32);
        builder.Property(a => a.ThemeKey).HasMaxLength(64);
        builder.Property(a => a.ServerAddress).IsRequired().HasMaxLength(512);
        builder.Property(a => a.Username).IsRequired().HasMaxLength(256);
        builder.Property(a => a.PasswordCredentialKey).IsRequired().HasMaxLength(256);
        builder.Property(a => a.OutputDevice).HasMaxLength(256);
    }

    void ConfigureAlbumMedia(EntityTypeBuilder<DbAlbumMedia> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Album).WithMany(a => a.Media).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.CoverArt).WithMany().OnDelete(DeleteBehavior.Cascade);
    }

    void ConfigureCoverArt(EntityTypeBuilder<DbCoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.LocalCacheEntries).WithOne(a => a.ParentItem).OnDelete(DeleteBehavior.Cascade);
    }

    void ConfigureCachedCoverArt(EntityTypeBuilder<DbCachedCoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries).OnDelete(DeleteBehavior.Cascade);
    }

    void ConfigureCachedSong(EntityTypeBuilder<DbCachedSong> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries).OnDelete(DeleteBehavior.Cascade);
    }
}
