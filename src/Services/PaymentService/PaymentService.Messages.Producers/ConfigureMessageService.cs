using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SelenyumMicroService.Shared.MessageService;

namespace PaymentService.Messages.Producers
{
    public static class ConfigureMessageService
    {
        public static void AddMessageService(this IServiceCollection services, IMessageServiceConnectionSettings settings)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri($"{settings.MessageService}/{settings.VirtualHost}"), hst =>
                    {
                        hst.Username(settings.MessageUser);
                        hst.Password(settings.MessagePass);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}