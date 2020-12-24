namespace Micro.Auth.Application.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(string username);
    }
}
