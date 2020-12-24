using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Micro.Auth.Application.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEnumerable<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "john.doe",
                Password = "password"
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Username = "jane.doe",
                Password = "b3tt3rp4ssw0rd"
            }
        };

        public void Authenticate(string username, string password)
        {
            if (_users.SingleOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password)) == null)
                throw new SecurityException("Invalid credentials");
        }
    }
}
