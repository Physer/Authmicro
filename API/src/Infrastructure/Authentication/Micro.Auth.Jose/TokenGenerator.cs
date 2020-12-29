using Jose;
using Micro.Auth.Application.Interfaces;
using Micro.Auth.Domain.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using static Jose.JWT;

namespace Micro.Auth.Jose
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly AuthenticationOptions _authenticationOptions;
        
        public TokenGenerator(IOptions<AuthenticationOptions> authenticationOptions)
        {
            _authenticationOptions = authenticationOptions.Value;
        }

        public string GenerateToken(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("No username provided");

            if (string.IsNullOrWhiteSpace(_authenticationOptions?.Secret))
                throw new Exception("No key found to sign the token with");

            if (string.IsNullOrWhiteSpace(_authenticationOptions.Issuer))
                throw new Exception("No JWT issuer found");

            var expiryTimestamp = ((DateTimeOffset)DateTime.UtcNow.AddHours(1)).ToUnixTimeSeconds();
            var payload = new Dictionary<string, object>()
            {
                { "sub", username },
                { "exp", expiryTimestamp },
                { "iss", _authenticationOptions.Issuer }
            };

            var secretKey = Encoding.UTF8.GetBytes(_authenticationOptions.Secret);

            return Encode(payload, secretKey, JwsAlgorithm.HS256);
        }
    }
}
