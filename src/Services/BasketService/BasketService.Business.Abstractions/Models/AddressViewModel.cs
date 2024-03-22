namespace BasketService.Business.Abstractions.Models
{
    public class AddressViewModel
    {
        public string City { get; init; }
        public string Street { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }

        public AddressViewModel(string city, string street, string state, string country, string zipCode)
        {
            City = city;
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}