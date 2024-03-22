namespace IdentityService.Business.Abstractions.Entities
{
    public class LoginRequestModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}