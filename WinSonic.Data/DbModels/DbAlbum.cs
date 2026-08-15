using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class DbAlbum : ICacheableEntity, IStarrable, IRateable, IReleaseDate, ISortable
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string? SortTitle { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public ReleaseDateType? ReleaseDateType { get; set; }
    public string? Version { get; set; }
    
    public string? ArtistName { get; set; }
    //public Artist? Artist { get; set; }

    public virtual DbCoverArt? CoverArt { get; set; }

    [Required]
    public int SongCount { get; set; }
    [Required]
    public int Duration { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? StarredAt { get; set; }
    public DateTime? PlayedAt { get; set; }

    public string DisplayArtist { get; set; }

    public bool IsCompilation { get; set; }
    public bool IsExplicit { get; set; }

    public int? Rating { get; set; }
    
    public virtual ICollection<DbAlbumMedia> Media { get; set; }
    public virtual ICollection<DbSong> Songs { get; set; }
    public virtual ICollection<DbArtist> Artists { get; set; }
   
    
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
}
