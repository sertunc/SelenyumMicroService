namespace BasketService.Common.ViewModels
{
    public record CustomerBasketViewModel(string BuyerId, List<BasketItemViewModel> Items);
}