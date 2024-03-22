using System.ComponentModel.DataAnnotations;

namespace BasketService.Business.Abstractions.Models
{
    public class BasketItemViewModel : IValidatableObject
    {
        public string Id { get; init; }
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal UnitPrice { get; init; }
        public decimal OldUnitPrice { get; init; }
        public int Quantity { get; init; }
        public string PictureUrl { get; init; }

        public BasketItemViewModel(string id, string productId, string productName, decimal unitPrice, decimal oldUnitPrice, int quantity, string pictureUrl)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            OldUnitPrice = oldUnitPrice;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Quantity < 1)
            {
                results.Add(new ValidationResult("Quantity should be greater than 0.", new[] { nameof(Quantity) }));
            }

            return results;
        }
    }
}