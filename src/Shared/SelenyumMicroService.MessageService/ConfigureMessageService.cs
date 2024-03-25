using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SelenyumMicroService.MessageService
{
    public static class ConfigureMessageService
    {
        public static void AddMessageService(this IServiceCollection services, MessageServiceConnectionSettings settings)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumers(Assembly.GetEntryAssembly());

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