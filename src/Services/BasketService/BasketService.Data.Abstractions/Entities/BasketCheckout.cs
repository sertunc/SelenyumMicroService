using BasketService.Data.Abstractions.ValueObjects;

namespace BasketService.Data.Abstractions.Entities
{
    public record BasketCheckout(Address ShippingAddress, CardInfo CardInfo, string BuyerId);
}