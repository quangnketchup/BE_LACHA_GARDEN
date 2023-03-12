using LachaGarden.Models;
using LachaGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;

        public UsersController(IConfiguration configuration, ITokenService tokenService)
        {
            this.configuration = configuration;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("sign-in")]
        public IActionResult Post(UserModel userModel)
        {
            return Ok(tokenService.BuildToken(configuration["Jwt:AuthDemo:Key"], configuration["Jwt:AuthDemo:ValidIssuer"], userModel));
        }
    }
}