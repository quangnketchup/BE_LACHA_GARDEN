using BusinessLayer.Models;
using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using LachaGarden.Services;
using DataAccessLayer.Models;
using Org.BouncyCastle.Crypto.Macs;
using System.Collections;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomTokenController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;
        private readonly IConfiguration _configuration;

        public CustomTokenController(ICustomerRepository customerRepository, IConfiguration configuration, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        public async Task<Dictionary<string, string>> GetTokenInfo(string token)
        {
            var TokenInfo = new Dictionary<string, string>();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }
            var keys = TokenInfo.Keys;
            var values = TokenInfo.Values;
            var uid = "";
            foreach (var key in keys)
            {
                var value = TokenInfo[key];

                if (key.Equals("user_id"))
                {
                    uid = value;
                }
                if (key.Equals("email"))
                {
                    Customer customer = await _customerRepository.GetCustomerByEmail(value);
                    var ListCustomer = _customerRepository.GetCustomers();
                    var count = ListCustomer.Count();
                    if (uid.Equals(""))
                    {
                        uid = (count + 1).ToString();
                    }
                    if (customer == null)
                    {
                        Customer newcustomer = new Customer
                        {
                            Status = 1,
                            Gmail = value,
                            Id = uid,
                            FullName = value,
                            Gender = 1,
                            Password = value,
                            Phone = 02873005585
                        };
                        _customerRepository.InsertCustomer(newcustomer);
                    }
                    else
                    {
                        return TokenInfo;
                    }
                }
            }
            return TokenInfo;
        }

        [HttpPost("TokenAdmin")]
        public async Task<Dictionary<string, string>> GetTokenInfoWithUser(string token)
        {
            var TokenInfo = new Dictionary<string, string>();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }

            var modifiedTokenInfo = new Dictionary<string, string>(TokenInfo); // create a new dictionary

            var uid = "";
            foreach (var key in TokenInfo.Keys)
            {
                var value = TokenInfo[key];

                if (key.Equals("user_id"))
                {
                    uid = value;
                }
                if (key.Equals("email"))
                {
                    User user = await userRepository.GetUserByEmail(value);
                    int roleID = user.RoleId ?? 0;
                    Role role = roleRepository.GetRoleByID((int)roleID);
                    if (user == null)
                    {
                        modifiedTokenInfo.Add("user", "User don't allowed access web page");
                        break;
                    }
                    else
                    {
                        modifiedTokenInfo.Add("roleName", role.RoleName);
                    }
                }
            }

            return modifiedTokenInfo; // return the new dictionary
        }

        [HttpPost("TokenWeb")]
        public async Task<IActionResult> GetTokenInfoWeb(string token)
        {
            var TokenInfo = new Dictionary<string, string>();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, (claim.Value));
            }

            var modifiedTokenInfo = new Dictionary<string, string>(TokenInfo); // create a new dictionary
            ArrayList list = new ArrayList();
            var uid = "";

            foreach (var key in TokenInfo.Keys)
            {
                var value = TokenInfo[key];

                if (key.Equals("roleID"))
                {
                    uid = value.ToString();
                }
                if (key.Equals("email"))
                {
                    User user = await userRepository.GetUserByEmail(value.ToString());
                    try
                    {
                        if (user == null)
                        {
                            throw new Exception("Error login");
                        }
                        else
                        {
                            int roleID = user.RoleId ?? 0;
                            Role role = roleRepository.GetRoleByID(roleID);
                            int roleId = role.RoleId;

                            modifiedTokenInfo.Add("roleID", (roleId.ToString()));
                            return Ok(role);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return Ok(list); // return the new dictionary
        }
    }
}