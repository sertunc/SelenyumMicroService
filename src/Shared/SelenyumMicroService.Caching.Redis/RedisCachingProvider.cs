using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace SelenyumMicroService.Caching.Redis
{
    public class RedisCachingProvider : ICache
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCachingProvider(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, object value)
        {
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), new DistributedCacheEntryOptions());
            return true;
        }

        public async Task<bool> SetValueAsync(string key, object value, object options)
        {
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), (DistributedCacheEntryOptions)options);
            return true;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class
        {
            var cachedValue = await GetValueAsync(key);
            if (cachedValue != null)
            {
                return JsonSerializer.Deserialize<T>(cachedValue);
            }

            var newValue = await action();
            await SetValueAsync(key, JsonSerializer.Serialize(newValue));
            return newValue;
        }

        public async Task RemoveAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}