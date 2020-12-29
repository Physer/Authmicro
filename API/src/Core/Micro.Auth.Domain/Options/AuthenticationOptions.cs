namespace Micro.Auth.Domain.Options
{
    public class AuthenticationOptions
    {
        public static string ConfigurationEntry => "Authentication";

        public string Secret { get; set; }
        public string Issuer { get; set; }
    }
}
