using MassTransit;
using Microsoft.Extensions.Logging;
using BasketService.Messages.Events;
using BasketService.Messages.Producers.Abstractions;

namespace BasketService.Messages.Producers.MassTransit
{
    public class BasketPublishes : IBasketPublishes
    {
        private readonly IBus bus;
        private readonly ILogger<BasketPublishes> logger;

        public BasketPublishes(IBus bus, ILogger<BasketPublishes> logger)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishOrderCreatedAsync(OrderCreated orderCreated)
        {
            logger.LogWarning("Payment success event publish with BuyerId: {BuyerId}", orderCreated.BuyerId);

            await bus.Publish(orderCreated);
        }
    }
}