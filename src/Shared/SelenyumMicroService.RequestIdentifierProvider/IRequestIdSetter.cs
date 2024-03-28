namespace SelenyumMicroService.RequestIdentifierProvider
{
    public interface IRequestIdSetter
    {
        void SetRequestId(string requestId);
    }
}