using SelenyumMicroService.RequestIdentifierProvider;
using SelenyumMicroService.TokenProvider;

namespace SelenyumMicroService.Api.Client.BaseClients
{
    public abstract class ClientWithToken : ClientWithRequestId
    {
        protected readonly ITokenProvider tokenProvider;

        protected ClientWithToken(HttpClient httpClient, IRequestIdProvider requestIdProvider, ITokenProvider tokenProvider) : base(httpClient, requestIdProvider)
        {
            this.tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));

            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenProvider.AccessToken}");
        }
    }
}