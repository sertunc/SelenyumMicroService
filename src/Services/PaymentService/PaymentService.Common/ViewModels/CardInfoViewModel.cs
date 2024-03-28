namespace PaymentService.Common.ViewModels
{
    public record CardInfoViewModel(string CardNumber, string CardHolderName, string CardExpiration, string CardSecurityCode, string CardType);
}