using LibrarySystem.Services.IServices.AppServices;
using Microsoft.Extensions.Caching.Memory;

namespace LibrarySystem.Services.Services.AppServices
{
    public class CacheProviderService(IMemoryCache cache) : ICacheProviderService
    {
        private readonly IMemoryCache _cache = cache;

        public T? GetValueFromCache<T>(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out T value);
            return value;
        }

        public void RemoveValueFromCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public void SaveValueToCache<T>(string cacheKey, T cacheValue, TimeSpan expirationTime)
        {
            _cache.Set(cacheKey, cacheValue, expirationTime);
        }
    }
}
