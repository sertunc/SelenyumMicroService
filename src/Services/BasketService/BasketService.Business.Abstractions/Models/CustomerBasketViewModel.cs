namespace BasketService.Business.Abstractions.Models
{
    public class CustomerBasketViewModel
    {
        public string BuyerId { get; init; }
        public List<BasketItemViewModel> Items { get; init; }

        public CustomerBasketViewModel(string buyerId, List<BasketItemViewModel> items)
        {
            BuyerId = buyerId;
            Items = items;
        }
    }
}