namespace OrderService.Domain.AggregateModels.OrderAggregate
{
    public record OrderItem
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public string PictureUrl { get; init; }
        public decimal Price { get; init; }

        public OrderItem(string productId, string productName, string pictureUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
        }
    }
}