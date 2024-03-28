namespace PaymentService.Common.ViewModels
{
    public record PaymentViewModel(CardInfoViewModel CardInfo, string BuyerId, decimal Amount);
}