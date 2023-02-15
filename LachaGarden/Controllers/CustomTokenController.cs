using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomTokenController : ControllerBase
    {
        [HttpPost]
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
