using WinSonic.Data.DbModels;

namespace WinSonic.Data.Utilities;

public static class Utilities
{
    public static TCachableEntity AddDefaultCacheables<TCachableEntity>(this TCachableEntity cacheable, int defaultCacheExpiryMins, DateTime? expiry = null) where TCachableEntity : ICacheableEntity
    {
        var actualExpiry = expiry ?? DateTime.UtcNow.AddMinutes(defaultCacheExpiryMins);

        cacheable.CacheExpires = actualExpiry;
        cacheable.CacheId = Guid.NewGuid();
        cacheable.CacheLastUpdated = DateTime.UtcNow;

        return cacheable;
    } 
}
