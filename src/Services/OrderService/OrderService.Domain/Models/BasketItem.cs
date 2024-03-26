namespace OrderService.Domain.Models
{
    //TODO: it can be record?
    public class BasketItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}