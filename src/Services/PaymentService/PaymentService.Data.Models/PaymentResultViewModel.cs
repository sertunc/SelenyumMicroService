namespace PaymentService.Data.Models
{
    public record PaymentResultViewModel(string OrderId, string PaymentId, bool IsSuccess, string Message);
}