using IdentityService.Business.Abstractions.Entities;

namespace IdentityService.Business.Abstractions.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);
    }
}