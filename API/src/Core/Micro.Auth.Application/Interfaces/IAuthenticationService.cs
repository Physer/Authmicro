namespace Micro.Auth.Application.Interfaces
{
    public interface IAuthenticationService
    {
        void Authenticate(string username, string password);
    }
}