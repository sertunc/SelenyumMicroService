using System.ComponentModel.DataAnnotations;

namespace BasketService.Data.Models
{
    public record BasketItem(string Id, string ProductId, string ProductName, decimal UnitPrice, decimal OldUnitPrice, int Quantity, string PictureUrl)
    {
        public IEnumerable<ValidationResult> Validate()
        {
            if (Quantity < 1)
            {
                yield return new ValidationResult("Quantity should be greater than 0.", new[] { nameof(Quantity) });
            }
        }
    }
}