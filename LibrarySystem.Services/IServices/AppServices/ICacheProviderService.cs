namespace LibrarySystem.Services.IServices.AppServices
{
    /// <summary>
    /// Provides methods for caching data in memory, including saving, retrieving, and removing cached values.
    /// </summary>
    public interface ICacheProviderService
    {
        /// <summary>
        /// Set value to memory cache and will expire in the given duration from now.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheValue"></param>
        /// <param name="expirationTime"></param>
        public void SaveValueToCache<T>(string cacheKey, T cacheValue, TimeSpan expirationTime);

        /// <summary>
        /// Get value from Memory cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T? GetValueFromCache<T>(string cacheKey);

        /// <summary>
        /// Remove value from Memory cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        public void RemoveValueFromCache(string cacheKey);
    }
}
