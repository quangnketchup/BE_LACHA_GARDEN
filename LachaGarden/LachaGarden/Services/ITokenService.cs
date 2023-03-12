using LachaGarden.Models;

namespace LachaGarden.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, UserModel userModel);
    }
}