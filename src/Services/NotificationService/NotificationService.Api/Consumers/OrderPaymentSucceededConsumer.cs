using MassTransit;
using PaymentService.Messages.Events;

namespace NotificationService.Api.Consumers
{
    public class OrderPaymentSucceededConsumer : IConsumer<OrderPaymentSucceeded>
    {
        private readonly ILogger<OrderPaymentSucceededConsumer> _logger;

        public OrderPaymentSucceededConsumer(ILogger<OrderPaymentSucceededConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<OrderPaymentSucceeded> context)
        {
            _logger.LogWarning("OrderPaymentSucceededConsumer-OrderId: {OrderId} PaymentId: {PaymentId}",
                context.Message.OrderId,
                context.Message.PaymentId);

            return Task.CompletedTask;
        }
    }
}