using Microsoft.Extensions.Logging;
using PaymentService.Client.Abstractions;
using PaymentService.Common.ViewModels;
using SelenyumMicroService.Api.Client.BaseClients;
using SelenyumMicroService.RequestIdentifierProvider;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Client
{
    public class PaymentServiceClient : ClientWithRequestId, IPaymentServiceClient
    {
        private readonly ILogger<PaymentServiceClient> logger;

        public PaymentServiceClient(ILogger<PaymentServiceClient> logger, HttpClient httpClient, IRequestIdProvider requestIdProvider)
            : base(httpClient, requestIdProvider)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel)
        {
            logger.LogDebug("PaymentServiceClient Pay method called with BuyerId:{BuyerId}", payViewModel.BuyerId);

            var result = await base.Post<Response<PaymentResultViewModel>, PaymentViewModel>("payment", payViewModel);

            return result;
        }
    }
}