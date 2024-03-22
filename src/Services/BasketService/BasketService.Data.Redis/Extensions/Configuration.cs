using BasketService.Data.Abstractions.Interfaces;
using BasketService.Data.Redis.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SelenyumMicroService.Caching.Redis;
using SelenyumMicroService.Caching;

namespace BasketService.Data.Redis.Extensions
{
    public static class Configuration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICache, RedisCachingProvider>();
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}