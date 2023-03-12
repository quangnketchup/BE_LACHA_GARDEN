using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace LachaGarden.Services
{
    public static class AuthHelper
    {
        public static string BuildToken(string key, string issuer, string id, string email)
        {
            // TODO: put real-world logic to evaluate sign-in credetials
            // ...
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Email, email),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer: issuer, audience: issuer, claims, expires: DateTime.Now.AddDays(365), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public static string HashPassword(string password)
        {
            return BC.HashPassword(password, 11);
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return string.Equals(inputPassword, hashedPassword);
            //return BC.Verify(inputPassword, hashedPassword);
        }
    }
}