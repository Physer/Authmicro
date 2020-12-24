using Micro.Auth.Application.Authentication;
using Micro.Auth.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.Auth.Startup
{
    public static class DependencyRegistrator
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}
