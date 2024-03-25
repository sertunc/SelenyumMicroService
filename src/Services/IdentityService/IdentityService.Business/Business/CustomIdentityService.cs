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
        private const string TokenSecret = "SelenyumMicroServiceSuperSecureKey";
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(1);

        public Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            // DB Process will be here. Check username and password

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, loginRequestModel.Username),
                new(JwtRegisteredClaimNames.Email, loginRequestModel.Username),
                new("userid", loginRequestModel.Username)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = "SelenyumMicroService",
                Audience = "SelenyumMicroService",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedToken = tokenHandler.WriteToken(token);

            return Task.FromResult(new LoginResponseModel(loginRequestModel.Username, encodedToken));
        }
    }
}