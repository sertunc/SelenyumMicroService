namespace BasketService.Business.Abstractions.Models
{
    public class CardInfoViewModel
    {
        public string CardNumber { get; init; }
        public string CardHolderName { get; init; }
        public string CardExpiration { get; init; }
        public string CardSecurityCode { get; init; }
        public string CardType { get; init; }

        public CardInfoViewModel(string cardNumber, string cardHolderName, string cardExpiration, string cardSecurityCode, string cardType)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CardExpiration = cardExpiration;
            CardSecurityCode = cardSecurityCode;
            CardType = cardType;
        }
    }
}