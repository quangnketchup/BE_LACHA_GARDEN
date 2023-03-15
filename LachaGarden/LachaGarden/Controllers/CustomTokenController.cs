using BusinessLayer.Models;
using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using LachaGarden.Services;
using DataAccessLayer.Models;
using Org.BouncyCastle.Crypto.Macs;

namespace LachaGarden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomTokenController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public CustomTokenController(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _configuration = configuration;
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
    }
}