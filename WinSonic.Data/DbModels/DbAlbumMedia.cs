namespace WinSonic.Data.DbModels;

public class DbAlbumMedia : ICacheableEntity
{
    public Guid Id { get; set; }
    public virtual DbAlbum Album { get; set; }
    public int DiscId { get; set; }
    public virtual DbCoverArt? CoverArt { get; set; }
    public string Name { get; set; }
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
}
