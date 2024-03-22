namespace BasketService.Business.Abstractions.Models
{
    public class BasketCheckoutViewModel
    {
        public AddressViewModel ShippingAddress { get; init; }
        public CardInfoViewModel CardInfo { get; init; }
        public string BuyerId { get; init; }
    }
}