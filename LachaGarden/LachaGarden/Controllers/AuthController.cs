using BussinessLayer.IRepository;
using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace LachaGarden.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public AuthController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        public async Task<ActionResult> GetToken(LoginInfo loginInfo)
        {
            var UserList = userRepository.GetUsers();
            if (UserList == null)
            {
                return BadRequest();
            }
            string uri = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/verifyPassword?key=AIzaSyAp7q2T07VOPchctK0RVVFfdNU9KAjo1Uc";
            using (HttpClient client = new HttpClient())
            {
                FireBaseLoginInfo fireBaseLoginInfo = new FireBaseLoginInfo
                {
                    Email = loginInfo.Username,
                    Password = loginInfo.Password
                };

                var result = await client.PostAsJsonAsync<FireBaseLoginInfo, GoogleToken>(uri, fireBaseLoginInfo);
                if (result != null)
                {
                    Token token = new Token
                    {
                        token_type = "Bearer",
                        access_token = result.idToken,
                        id_token = result.idToken,
                        expires_in = int.Parse(result.expiresIn),
                        refresh_token = result.refreshToken
                    };
                    foreach (User user in UserList)
                    {
                        if (user.Gmail == loginInfo.Username)
                        {
                            var RoleList = roleRepository.GetRoles();
                            foreach (Role role in RoleList)
                            {
                                if (user.RoleId == role.RoleId)
                                {
                                    token.roleId = role.RoleId;
                                }
                            }
                        }
                    }
                    return Ok(token);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}