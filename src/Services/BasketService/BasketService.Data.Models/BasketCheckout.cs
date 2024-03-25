namespace BasketService.Data.Models
{
    public record BasketCheckout(Address ShippingAddress, CardInfo CardInfo, string BuyerId);
}