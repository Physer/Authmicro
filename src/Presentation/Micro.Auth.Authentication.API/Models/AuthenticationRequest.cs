using Micro.Auth.Application.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Micro.Auth.Authentication.API.Models
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Audience Audience { get; set; }
    }
}
