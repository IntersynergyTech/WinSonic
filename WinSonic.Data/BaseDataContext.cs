using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

    public DbSet<DbCachedCoverArt> CachedCoverArt { get; set; }
    public DbSet<DbCachedSong> CachedSongs { get; set; }

    public void UpdateMigrationState()
    {
        if (Database.GetPendingMigrations().Any())
        {
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
    }

    void ConfigureAlbum(EntityTypeBuilder<DbAlbum> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SortTitle).HasMaxLength(200);

        //builder.HasOne(a => a.Artist).WithMany(a => a.Albums);

        builder.HasOne(a => a.CoverArt);

        builder.HasMany(a => a.Songs).WithOne(a => a.Album);
        builder.HasMany(a => a.Media).WithOne(a => a.Album);
        builder.HasMany(a => a.Artists).WithMany(a => a.Albums);
    }

    void ConfigureArtist(EntityTypeBuilder<DbArtist> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SortTitle).HasMaxLength(200);

        builder.HasOne(a => a.CoverArt);

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

        builder.HasOne(a => a.CoverArt);

        builder.HasMany(a => a.Songs).WithMany(a => a.AppearsInPlaylists);
    }

    void ConfigureSong(EntityTypeBuilder<DbSong> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.HasOne(a => a.Album).WithMany(a => a.Songs);
        builder.HasOne(a => a.Artist);
        builder.HasOne(a => a.CoverArt);

        builder.HasMany(a => a.Artists).WithMany(a => a.Songs).UsingEntity("SongToArtists");;
        builder.HasMany(a => a.AppearsInPlaylists).WithMany(a => a.Songs);
        
        builder.HasMany(a => a.AlbumArtists).WithMany(a => a.SongsAsAlbumArtist).UsingEntity("SongToAlbumArtists");

        builder.HasMany(a => a.LocalCacheEntries).WithOne(a => a.ParentItem);
    }
    
    void ConfigurePlayHistory(EntityTypeBuilder<DbPlayHistoryEntry> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Song);
    }
    
    void ConfigurePlayQueue(EntityTypeBuilder<DbPlayQueueEntry> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Song);
    }

    void ConfigureAlbumMedia(EntityTypeBuilder<DbAlbumMedia> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Album).WithMany(a => a.Media);
    }

    void ConfigureCoverArt(EntityTypeBuilder<DbCoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.LocalCacheEntries).WithOne(a => a.ParentItem);
    }

    void ConfigureCachedCoverArt(EntityTypeBuilder<DbCachedCoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries);
    }

    void ConfigureCachedSong(EntityTypeBuilder<DbCachedSong> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries);
    }
}
