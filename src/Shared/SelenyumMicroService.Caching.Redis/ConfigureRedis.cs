using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace SelenyumMicroService.Caching.Redis
{
    public static class ConfigureRedis
    {
        public static void AddRedisCacheService(this IServiceCollection services, RedisSettings redisSettings)
        {
            ArgumentNullException.ThrowIfNull(redisSettings.Addresses);

            var endpoints = new EndPointCollection();
            redisSettings.Addresses.ToList().ForEach(x => endpoints.Add(x));

            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = endpoints
            };

            if (!string.IsNullOrEmpty(redisSettings.Username) && !string.IsNullOrEmpty(redisSettings.Password))
            {
                configurationOptions.User = redisSettings.Username;
                configurationOptions.Password = redisSettings.Password;
            }

            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = configurationOptions;
            });
        }
    }
}