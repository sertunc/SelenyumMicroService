namespace OrderService.Domain.Models
{
    //TODO: it can be record?
    public class CustomerBasket
    {
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket()
        {
        }

        public CustomerBasket(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}