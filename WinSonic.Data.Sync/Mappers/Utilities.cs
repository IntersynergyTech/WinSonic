using WinSonic.Data.DbModels;

namespace WinSonic.Data.Sync.Mappers;

public static class Utilities
{
    public static TCachableEntity AddDefaultCacheables<TCachableEntity>(this TCachableEntity cacheable, DateTime? expiry = null) where TCachableEntity : ICacheableEntity
    {
        var actualExpiry = expiry ?? DateTime.UtcNow.AddMinutes(SyncManager.DefaultCacheExpiryMins);

        cacheable.CacheExpires = actualExpiry;
        cacheable.CacheId = Guid.NewGuid();
        cacheable.CacheLastUpdated = DateTime.UtcNow;

        return cacheable;
    } 
}
