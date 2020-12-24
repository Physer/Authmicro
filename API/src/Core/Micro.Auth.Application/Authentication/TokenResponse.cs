namespace Micro.Auth.Application.Authentication
{
    public class TokenResponse
    {
        public TokenResponse(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; }
    }
}
