using System;
using System.Runtime.Caching;

namespace Interpidians.Catalyst.Core.ApplicationService
{
    public class CacheService : ICacheService
    {
        public TValue Get<TValue>(string cacheKey, int durationInMinutes, Func<TValue> getItemCallback) where TValue : class
        {
            TValue item = MemoryCache.Default.Get(cacheKey) as TValue;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(durationInMinutes));
            }
            return item;
        }

        public TValue Get<TValue, TId>(string cacheKeyFormat, TId id, int durationInMinutes, Func<TId, TValue> getItemCallback) where TValue : class
        {
            string cacheKey = string.Format(cacheKeyFormat, id);
            TValue item = MemoryCache.Default.Get(cacheKey) as TValue;
            if (item == null)
            {
                item = getItemCallback(id);
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(durationInMinutes));
            }
            return item;
        }
    }
}
