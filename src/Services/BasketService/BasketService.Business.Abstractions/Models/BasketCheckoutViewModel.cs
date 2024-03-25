using BasketService.Business.Abstractions.Models;

namespace BasketService.Business.Abstractions.Models
{
    public record BasketCheckoutViewModel(AddressViewModel ShippingAddress, CardInfoViewModel CardInfo, string BuyerId);
}