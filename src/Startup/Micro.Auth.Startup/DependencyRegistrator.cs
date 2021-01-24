using Micro.Auth.Application.Authentication;
using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Options;
using Micro.Auth.Jose;
using Micro.Auth.JsonPlaceHolder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

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

        public static void RegisterHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IAccountRepository, JsonPlaceholderRepository>(ConfigureJsonPlaceholderClient);
            services.AddHttpClient<IPostRepository, JsonPlaceholderRepository>(ConfigureJsonPlaceholderClient);
        }

        private static void ConfigureJsonPlaceholderClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
