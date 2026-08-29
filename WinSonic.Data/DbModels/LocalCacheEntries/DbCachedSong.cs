namespace WinSonic.Data.DbModels.LocalCacheEntries;

public class DbCachedSong : ICacheableEntity, ILocalCacheItem<DbSong>
{
    public bool IsOriginal { get; set; }

    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public Guid Id { get; set; }
    public string Filename { get; set; }
    public string Format { get; set; }
    public virtual DbSong ParentItem { get; set; }
    public int Bitrate { get; set; }
    public int Filesize { get; set; }
}
