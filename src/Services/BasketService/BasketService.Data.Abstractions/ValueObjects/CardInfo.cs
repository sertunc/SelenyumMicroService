namespace BasketService.Data.Abstractions.ValueObjects
{
    public class CardInfo
    {
        public string CardNumber { get; init; }
        public string CardHolderName { get; init; }
        public string CardExpiration { get; init; }
        public string CardSecurityCode { get; init; }
        public string CardType { get; init; }

        public CardInfo(string cardNumber, string cardHolderName, string cardExpiration, string cardSecurityCode, string cardType)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CardExpiration = cardExpiration;
            CardSecurityCode = cardSecurityCode;
            CardType = cardType;
        }
    }
}