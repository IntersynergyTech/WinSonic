namespace WinSonic.Data.DbModels;

public class AlbumMedia : ICacheableEntity
{
    public Guid Id { get; set; }
    public Album Album { get; set; }
    public int DiscId { get; set; }
    public CoverArt? CoverArt { get; set; }
    public string Name { get; set; }
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
}
