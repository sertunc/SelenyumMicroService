using Microsoft.Extensions.Logging;
using SelenyumMicroService.RequestIdentifierProvider;

namespace SelenyumMicroService.Api.Client.BaseClients
{
    public abstract class ClientWithRequestId : JsonClient
    {
        protected readonly IRequestIdGetter requestIdGetter;

        protected ClientWithRequestId(ILogger<JsonClient> logger, HttpClient httpClient, IRequestIdGetter requestIdGetter) : base(logger, httpClient)
        {
            this.requestIdGetter = requestIdGetter ?? throw new ArgumentNullException(nameof(requestIdGetter));
        }

        private void SetHeaderRequestId()
        {
            httpClient.DefaultRequestHeaders.Remove("RequestId");
            httpClient.DefaultRequestHeaders.Add("RequestId", requestIdGetter.GetRequestId());
        }

        protected override async Task<TReturn> PostForm<TReturn>(string method, params (string Key, string Value)[] formData)
        {
            SetHeaderRequestId();
            return await base.PostForm<TReturn>(method, formData);
        }

        protected override Task PostForm(string method, params (string Key, string Value)[] formData)
        {
            SetHeaderRequestId();
            return base.PostForm(method, formData);
        }

        protected override Task Post<T>(string method, T request)
        {
            SetHeaderRequestId();
            return base.Post(method, request);
        }

        protected override Task<TReturn> Post<TReturn, T>(string method, T request)
        {
            SetHeaderRequestId();
            return base.Post<TReturn, T>(method, request);
        }

        protected override Task Get(string method)
        {
            SetHeaderRequestId();
            return base.Get(method);
        }

        protected override Task<TReturn> Get<TReturn>(string method)
        {
            SetHeaderRequestId();
            return base.Get<TReturn>(method);
        }
    }
}