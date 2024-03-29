using IdentityService.Common.ViewModels;

namespace IdentityService.Business.Abstractions
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);
    }
}