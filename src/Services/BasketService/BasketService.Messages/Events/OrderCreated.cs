using BasketService.Data.Models;

namespace BasketService.Messages.Events
{
    public record OrderCreated(string BuyerId, CustomerBasket CustomerBasket, BasketCheckout BasketCheckout);
}