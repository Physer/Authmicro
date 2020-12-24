using Micro.Auth.Application.Authentication;
using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Options;
using Micro.Auth.Jose;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.Auth.Startup
{
    public static class DependencyRegistrator
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
        }

        public static void RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationOptions.ConfigurationEntry));
        }
    }
}
