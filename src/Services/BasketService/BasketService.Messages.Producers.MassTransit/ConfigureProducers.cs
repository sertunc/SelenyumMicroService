using BasketService.Messages.Producers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Messages.Producers.MassTransit
{
    public static class ConfigureProducers
    {
        public static void AddProducers(this IServiceCollection services)
        {
            services.AddScoped<IBasketPublishes, BasketPublishes>();
        }
    }
}