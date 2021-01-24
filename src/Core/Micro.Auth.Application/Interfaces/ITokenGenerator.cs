using Micro.Auth.Application.Authentication;
using System.Collections.Generic;

namespace Micro.Auth.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(string username, Audience audience, IEnumerable<string> roles);
    }
}
