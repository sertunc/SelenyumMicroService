namespace BasketService.Data.Abstractions.Entities
{
    public record CustomerBasket(string BuyerId, List<BasketItem> Items);
}