using System.ComponentModel.DataAnnotations;
using WinSonic.Data.DbModels.LocalCacheEntries;

namespace WinSonic.Data.DbModels;

public class DbCoverArt : ICacheableEntity
{
    
    public DbCoverArt(string id)
    {
        Id = id;
    }
    
    [Required]
    public string Id { get; set; }
    
    public DateTime CacheLastUpdated { get; set; }
    public DateTime? CacheExpires { get; set; }
    public Guid CacheId { get; set; }

    public virtual ICollection<DbCachedCoverArt> LocalCacheEntries { get; set; }
}
