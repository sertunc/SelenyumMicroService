namespace BasketService.Common.ViewModels
{
    public record BasketCheckoutViewModel(AddressViewModel ShippingAddress, CardInfoViewModel CardInfo, string BuyerId);
}