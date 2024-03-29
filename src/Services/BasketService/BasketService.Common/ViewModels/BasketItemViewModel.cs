using System.ComponentModel.DataAnnotations;

namespace BasketService.Common.ViewModels
{
    public record BasketItemViewModel(string Id, string ProductId, string ProductName, decimal UnitPrice, int Quantity, string PictureUrl)
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