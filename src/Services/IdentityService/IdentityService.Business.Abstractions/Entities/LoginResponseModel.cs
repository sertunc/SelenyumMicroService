namespace IdentityService.Business.Abstractions.Entities
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}