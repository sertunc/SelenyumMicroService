using MassTransit;
using Microsoft.Extensions.Logging;
using PaymentService.Messages.Events;
using PaymentService.Messages.Producers.Abstractions.Interfaces;

namespace PaymentService.Messages.Producers.Publishes
{
    public class PaymentPublishes : IPaymentPublishes
    {
        private readonly IBus bus;
        private readonly ILogger<PaymentPublishes> logger;

        public PaymentPublishes(IBus bus, ILogger<PaymentPublishes> logger)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishPaymentFailedAsync(OrderPaymentFailed orderPaymentFailed)
        {
            logger.LogDebug("Payment fail event publish with message: {Message} and orderId: {OrderId}", orderPaymentFailed.Error, orderPaymentFailed.OrderId);

            await bus.Publish(orderPaymentFailed);
        }

        public async Task PublishPaymentSucceededAsync(OrderPaymentSucceeded orderPaymentSucceeded)
        {
            logger.LogDebug("Payment success event publish with orderId: {OrderId}", orderPaymentSucceeded.OrderId);

            await bus.Publish(orderPaymentSucceeded);
        }
    }
}