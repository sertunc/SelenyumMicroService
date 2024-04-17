namespace IdentityService.Api.ViewModels
{
    public record SignupRequestModel(string Name, string Surname, string Username, string Email, string Password, string ConfirmPassword);
}