using PaymentService.Common.ViewModels;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Client.Abstractions
{
    public interface IPaymentServiceClient
    {
        Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel);
    }
}