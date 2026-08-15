namespace WinSonic.Data.DbModels.LocalCacheEntries;

public class DbCachedCoverArt: ICacheableEntity, ILocalCacheItem<DbCoverArt>
{
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public Guid Id { get; set; }
    public string Filename { get; set; }
    public virtual DbCoverArt ParentItem { get; set; }
    public int? Dimension { get; set; }
}
