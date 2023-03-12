using LachaGarden.Models;

namespace LachaGarden.Services
{
    public interface IAuthService
    {
        Task<AuthDTO> Authenticate(string username, string password);

        //Task<AuthDTO> Authenticate(GoogleJsonWebSignature.Payload googlePayload);
    }
}