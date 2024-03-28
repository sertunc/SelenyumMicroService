namespace PaymentService.Data.Models
{
    public record PaymentViewModel(CardInfoViewModel CardInfo, string BuyerId, decimal Amount);
}