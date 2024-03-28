using Microsoft.Extensions.Logging;
using PaymentService.Client.Abstractions;
using PaymentService.Common.ViewModels;
using SelenyumMicroService.Api.Client.BaseClients;
using SelenyumMicroService.RequestIdentifierProvider;
using SelenyumMicroService.Shared.Dtos;
using SelenyumMicroService.TokenProvider;

namespace PaymentService.Client
{
    public class PaymentServiceClient : ClientWithToken, IPaymentServiceClient
    {
        private readonly ILogger<PaymentServiceClient> logger;

        public PaymentServiceClient(ILogger<PaymentServiceClient> logger, HttpClient httpClient, IRequestIdGetter requestIdGetter, ITokenGetter tokenGetter)
            : base(logger, httpClient, requestIdGetter, tokenGetter)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel)
        {
            //logger.LogDebug("PaymentServiceClient Pay metod giriş yaptı.");

            //var result = await base.Post<Response<bool>, PaymentViewModel>("api/ReceivePayment", payViewModel);

            //return result;

            throw new NotImplementedException();
        }
    }
}