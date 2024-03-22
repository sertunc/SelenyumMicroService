using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SelenyumMicroService.Bootstrapper
{
    public static class AuthenticationBootStrapper
    {
        public static IServiceCollection AddDefaultAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration["Identity:Issuer"];
            var audience = configuration["Identity:Audience"];
            var secretKey = configuration["Identity:SecretKey"];

            ArgumentNullException.ThrowIfNull(secretKey, nameof(secretKey));
            ArgumentNullException.ThrowIfNull(issuer, nameof(issuer));
            ArgumentNullException.ThrowIfNull(audience, nameof(audience));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            return services;
        }
    }
}