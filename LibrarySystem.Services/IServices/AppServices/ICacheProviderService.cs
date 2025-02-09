namespace LibrarySystem.Services.IServices.AppServices
{
    public interface ICacheProviderService
    {
        /// <summary>
        /// Set value to memory cache and will expire in the given duration from now.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="cacheValue"></param>
        /// <param name="expirationTime"></param>
        public void SaveValueToCache(string cacheKey, string cacheValue, TimeSpan expirationTime);
        /// <summary>
        /// Get value from Memory cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public string GetValueFromCache(string cacheKey);
        /// <summary>
        /// Remove value from Memory cache by cache key
        /// </summary>
        /// <param name="cacheKey"></param>
        public void RemoveValueFromCache(string cacheKey);

    }
}
