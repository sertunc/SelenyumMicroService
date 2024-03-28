using Microsoft.Extensions.Logging;
using SelenyumMicroService.RequestIdentifierProvider;
using SelenyumMicroService.TokenProvider;

namespace SelenyumMicroService.Api.Client.BaseClients
{
    public abstract class ClientWithToken : ClientWithRequestId
    {
        protected readonly ITokenGetter tokenGetter;

        protected ClientWithToken(ILogger<JsonClient> logger, HttpClient httpClient, IRequestIdGetter requestIdGetter, ITokenGetter tokenGetter) : base(logger, httpClient, requestIdGetter)
        {
            this.tokenGetter = tokenGetter ?? throw new ArgumentNullException(nameof(tokenGetter));

            var token = tokenGetter.GetAccessToken();

            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}