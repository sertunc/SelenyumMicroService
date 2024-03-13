using MassTransit;
using PaymentService.Messages.Events;

namespace NotificationService.Api.Consumers
{
    public class OrderPaymentFailedConsumer : IConsumer<OrderPaymentFailed>
    {
        private readonly ILogger<OrderPaymentFailedConsumer> _logger;

        public OrderPaymentFailedConsumer(ILogger<OrderPaymentFailedConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<OrderPaymentFailed> context)
        {
            _logger.LogError("OrderPaymentFailedConsumer-OrderId: {OrderId} Error:{Error}",
                context.Message.OrderId, context.Message.Error);

            return Task.CompletedTask;
        }
    }
}