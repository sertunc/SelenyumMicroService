namespace BasketService.Data.Models
{
    public record CustomerBasket(string BuyerId, List<BasketItem> Items);
}