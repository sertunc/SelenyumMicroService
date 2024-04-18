using IdentityService.Api.ViewModels;
using SelenyumMicroService.Shared.Dtos;

namespace IdentityService.Api.BusinessAbstractions
{
    public interface IIdentityService
    {
        Task<Response<LoginResponseModel>> LoginAsync(LoginRequestModel loginRequestModel);

        Task<Response<bool>> SignupAsync(SignupRequestModel signupRequestModel);

        Task<Response<UserProfileResponseModel>> UserProfileAsync();
    }
}