using Micro.Auth.Application.Authentication;

namespace Micro.Auth.Application.Interfaces
{
    public interface IAuthenticationService
    {
        TokenResponse Authenticate(string username, string password);
    }
}