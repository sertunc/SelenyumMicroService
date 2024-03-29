namespace SelenyumMicroService.RequestIdentifierProvider
{
    public interface IRequestIdProvider
    {
        string RequestId { get; }
    }
}