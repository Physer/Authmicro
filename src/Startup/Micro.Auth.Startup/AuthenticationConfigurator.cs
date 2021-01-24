using Micro.Auth.Domain.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Micro.Auth.Startup
{
    public static class AuthenticationConfigurator
    {
        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationOptions = configuration.GetSection(AuthenticationOptions.ConfigurationEntry).Get<AuthenticationOptions>();
            var tokenParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                RequireSignedTokens = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions?.Secret)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = authenticationOptions.Issuer,
                ValidAudience = authenticationOptions.Audience
            };

            services    
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenParameters;
            });
        }
    }
}
