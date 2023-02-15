using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace LachaGarden.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> GetToken([FromForm] LoginInfo loginInfo)
        {
            string uri = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=AIzaSyAp7q2T07VOPchctK0RVVFfdNU9KAjo1Uc";
            using (HttpClient client = new HttpClient())
            {
                FireBaseLoginInfo fireBaseLoginInfo = new FireBaseLoginInfo
                {
                    Email = loginInfo.Username,
                    Password = loginInfo.Password
                };
                var result = await client.PostAsJsonAsync<FireBaseLoginInfo, GoogleToken>(uri, fireBaseLoginInfo);
                Token token = new Token
                {
                    token_type = "Bearer",
                    access_token = result.idToken,
                    refresh_token = result.refreshToken,

                    expires_in = int.Parse(result.expiresIn),
                };
                return Ok(token);
            }
        }
    }
}
