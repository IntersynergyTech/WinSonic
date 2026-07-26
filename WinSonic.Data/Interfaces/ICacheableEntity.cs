namespace WinSonic.Data.DbModels;

public interface ICacheableEntity
{
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }
}
