using BasketService.Data.Abstractions.ValueObjects;

namespace BasketService.Data.Abstractions.Entities
{
    public class BasketCheckout
    {
        public Address ShippingAddress { get; init; }
        public CardInfo CardInfo { get; init; }
        public string BuyerId { get; init; }
    }
}