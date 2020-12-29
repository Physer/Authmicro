using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Constants;
using Micro.Auth.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Micro.Auth.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        private readonly IEnumerable<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "john.doe",
                Password = "password",
                Roles = new[] { AuthenticationConstants.AdministratorRole, AuthenticationConstants.ReaderRole }
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Username = "jane.doe",
                Password = "b3tt3rp4ssw0rd",
                Roles = new[] { AuthenticationConstants.ReaderRole }
            }
        };

        public TokenResponse Authenticate(string username, string password, Audience audience)
        {
            var currentUser = _users.SingleOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
            if (currentUser == null)
                throw new SecurityException("Invalid credentials");

            var accessToken = _tokenGenerator.GenerateToken(username, audience, currentUser.Roles);
            return new TokenResponse(accessToken);
        }
    }
}
