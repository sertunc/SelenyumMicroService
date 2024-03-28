namespace SelenyumMicroService.TokenProvider
{
    public interface ITokenSetter
    {
        void SetAccessToken(string token);
    }
}