using System.ComponentModel.DataAnnotations;
using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class DbArtist: ICacheableEntity, IStarrable, IRateable, ISortable
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Title { get; set; }
    
    public string? SortTitle { get; set; }
    public virtual DbCoverArt? CoverArt { get; set; }
    public int? AlbumCount { get; set; }
    public ArtistType? Type { get; set; }
    public DateTime? StarredAt { get; set; }
    public string? Disambiguation { get; set; }
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public int? Rating { get; set; }

    public virtual ICollection<DbAlbum> Albums { get; set; }
    public virtual ICollection<DbSong> Songs { get; set; }
    public virtual ICollection<DbSong> SongsAsAlbumArtist { get; set; }
    public virtual ICollection<string> Types { get; set; }  
}
