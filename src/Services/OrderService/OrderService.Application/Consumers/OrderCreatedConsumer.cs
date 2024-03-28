using BasketService.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace OrderService.Application.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly ILogger<OrderCreatedConsumer> _logger;

        public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            throw new NotImplementedException();
        }
    }
}