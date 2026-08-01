using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAlbum(modelBuilder.Entity<Album>());
        ConfigureArtist(modelBuilder.Entity<Artist>());
        ConfigureAlbumMedia(modelBuilder.Entity<AlbumMedia>());
        ConfigurePlaylist(modelBuilder.Entity<Playlist>());
        ConfigureSong(modelBuilder.Entity<Song>());
        ConfigureCoverArt(modelBuilder.Entity<CoverArt>());
        ConfigureCachedCoverArt(modelBuilder.Entity<CachedCoverArt>());
        ConfigureCachedSong(modelBuilder.Entity<CachedSong>());
        
    }

    void ConfigureAlbum(EntityTypeBuilder<Album> builder)
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

    void ConfigureArtist(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);

        builder.Property(a => a.SortTitle).HasMaxLength(200);

        builder.HasOne(a => a.CoverArt);

        builder.HasMany(a => a.Albums).WithMany(a => a.Artists);
        builder.HasMany(a => a.Songs).WithMany(a => a.Artists);
        builder.HasMany(a => a.SongsAsAlbumArtist).WithMany(a => a.AlbumArtists);
    }

    void ConfigurePlaylist(EntityTypeBuilder<Playlist> builder)
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

    void ConfigureSong(EntityTypeBuilder<Song> builder)
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

    void ConfigureAlbumMedia(EntityTypeBuilder<AlbumMedia> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Album).WithMany(a => a.Media);
    }

    void ConfigureCoverArt(EntityTypeBuilder<CoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasMany(a => a.LocalCacheEntries).WithOne(a => a.ParentItem);
    }

    void ConfigureCachedCoverArt(EntityTypeBuilder<CachedCoverArt> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries);
    }

    void ConfigureCachedSong(EntityTypeBuilder<CachedSong> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.ParentItem).WithMany(a => a.LocalCacheEntries);
    }
}
