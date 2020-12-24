using System.Security;

namespace Micro.Auth.Authentication.API.Models
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
