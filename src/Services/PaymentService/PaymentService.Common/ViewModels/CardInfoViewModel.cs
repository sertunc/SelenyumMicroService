namespace PaymentService.Data.Models
{
    public record CardInfoViewModel(string CardNumber, string CardHolderName, string CardExpiration, string CardSecurityCode, string CardType);
}