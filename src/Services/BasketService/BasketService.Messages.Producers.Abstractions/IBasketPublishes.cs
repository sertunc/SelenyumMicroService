using BasketService.Messages.Events;

namespace BasketService.Messages.Producers.Abstractions
{
    public interface IBasketPublishes
    {
        Task PublishOrderCreatedAsync(OrderCreated orderCreated);
    }
}