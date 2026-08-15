namespace WinSonic.Data.DbModels.LocalCacheEntries;

public class DbCachedSong : ICacheableEntity, ILocalCacheItem<DbSong>, IMediaFormat
{
    public bool IsOriginal { get; set; }

    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
    public Guid Id { get; set; }
    public string Filename { get; set; }
    public virtual DbSong ParentItem { get; set; }
    public int SampleRate { get; set; }
    public int BitDepth { get; set; }
    public int Bitrate { get; set; }
    public int ChannelCount { get; set; }
    public int Filesize { get; set; }
}
