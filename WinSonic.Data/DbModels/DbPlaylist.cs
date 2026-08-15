using System.ComponentModel.DataAnnotations;

namespace WinSonic.Data.DbModels;

public class DbPlaylist: ICacheableEntity
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Title { get; set; }

    public string? Owner { get; set; }
    
    [Required]
    public int SongCount { get; set; }
    [Required]
    public int Duration { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime UpdatedAt { get; set; }
    public virtual DbCoverArt? CoverArt { get; set; }

    public bool IsPublic { get; set; }
    public bool IsReadOnly { get; set; }

    public virtual ICollection<DbSong> Songs { get; set; }
    
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
}
