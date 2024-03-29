using Microsoft.AspNetCore.Http;
using SelenyumMicroService.RequestIdentifierProvider;

namespace SelenyumMicroService.Api.Client.Providers
{
    public class RequestIdProvider : IRequestIdProvider, IRequestIdSetter
    {
        private const string HeaderName = "X-Request-Id";

        private string _requestId;
        private readonly IHttpContextAccessor contextAccessor;

        public RequestIdProvider(IHttpContextAccessor contextAccessor)
        {
            _requestId = "";
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public string RequestId
        {
            get
            {
                if (!string.IsNullOrEmpty(_requestId)) { return _requestId; }

                if (!string.IsNullOrEmpty(contextAccessor.HttpContext.Request.Headers[HeaderName].ToString()))
                {
                    _requestId = contextAccessor.HttpContext.Request.Headers[HeaderName].ToString();
                    return _requestId;
                }

                _requestId = Guid.NewGuid().ToString();
                return _requestId;
            }
        }

        public void SetRequestId(string requestId)
        {
            _requestId = requestId;
        }
    }
}