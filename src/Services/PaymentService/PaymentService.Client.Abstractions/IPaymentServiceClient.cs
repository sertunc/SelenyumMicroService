using PaymentService.Data.Models;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Client.Abstractions
{
    public interface IPaymentServiceClient
    {
        Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel);
    }
}