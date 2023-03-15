using BussinessLayer.Repository;
using System.IdentityModel.Tokens.Jwt;

namespace LachaGarden.Services
{
    public class CheckCustomerToken
    {
        private UserRepository userRepository;

        public Dictionary<string, string> GetTokenInfo(string token)
        {
            var TokenInfo = new Dictionary<string, string>();

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();
            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }

            return TokenInfo;
        }
    }
}