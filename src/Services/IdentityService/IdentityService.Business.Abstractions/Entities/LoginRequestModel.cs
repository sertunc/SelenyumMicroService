namespace IdentityService.Business.Abstractions.Entities
{
    public record LoginRequestModel(string Name, string Username, string Password);
}