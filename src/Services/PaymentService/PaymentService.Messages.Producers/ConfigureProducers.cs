using Microsoft.Extensions.DependencyInjection;
using PaymentService.Messages.Producers.Abstractions.Interfaces;
using PaymentService.Messages.Producers.Publishes;

namespace PaymentService.Messages.Producers
{
    public static class ConfigureProducers
    {
        public static void AddProducers(this IServiceCollection services)
        {
            services.AddScoped<IPaymentPublishes, PaymentPublishes>();
        }
    }
}