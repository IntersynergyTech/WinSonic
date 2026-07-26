using System.ComponentModel.DataAnnotations;
using WinSonic.Data.Enums;

namespace WinSonic.Data.DbModels;

public class Artist: ICacheableEntity, IStarrable, IRateable
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public CoverArt? CoverArt { get; set; }
    public int? AlbumCount { get; set; }
    public ArtistType? Type { get; set; }
    public DateTime? StarredAt { get; set; }
    public string? Disambiguation { get; set; }
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public int? Rating { get; set; }
}
