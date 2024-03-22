namespace BasketService.Data.Abstractions.Entities
{
    public class CustomerBasket
    {
        public string BuyerId { get; init; }
        public List<BasketItem> Items { get; init; }

        public CustomerBasket(string buyerId, List<BasketItem> items)
        {
            BuyerId = buyerId;
            Items = items;
        }
    }
}