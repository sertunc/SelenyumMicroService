using IdentityService.Business.Abstractions.Entities;
using IdentityService.Business.Abstractions.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Business.Business
{
    public class CustomIdentityService : IIdentityService
    {
        public Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            // DB Process will be here. Check username and password

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, loginRequestModel.Username),
                new Claim(ClaimTypes.Name, "Sertunc Selen"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SelenyumMicroServiceSuperSecureKey"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: signingCredentials, notBefore: DateTime.Now);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(new LoginResponseModel { Token = encodedToken, UserName = loginRequestModel.Username });
        }
    }
}