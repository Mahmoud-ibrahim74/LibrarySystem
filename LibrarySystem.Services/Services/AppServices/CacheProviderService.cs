using LibrarySystem.Services.IServices.AppServices;
using Microsoft.Extensions.Caching.Memory;

namespace LibrarySystem.Services.Services.AppServices
{
    public class CacheProviderService(IMemoryCache cache) : ICacheProviderService
    {
        private readonly IMemoryCache _cache = cache;

        public string GetValueFromCache(string cacheKey)
        {
            _cache.TryGetValue(cacheKey, out string code);
            return code ?? string.Empty;
        }

        public void RemoveValueFromCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public void SaveValueToCache(string cacheKey, string cacheValue, TimeSpan expirationTime)
        {

            _cache.Set(cacheKey, cacheValue, expirationTime);
        }
    }
}
