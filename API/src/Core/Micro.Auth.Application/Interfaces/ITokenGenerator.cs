using Micro.Auth.Application.Authentication;

namespace Micro.Auth.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(string username, Audience audience);
    }
}
