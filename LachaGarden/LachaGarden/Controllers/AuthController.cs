using Abp.Domain.Uow;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Google.Apis.Auth;
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

        public class AuthService : IAuthService
        {
            private readonly IUserRepository _userRepository;
            private readonly ICustomerRepository _customerRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IConfiguration _configuration;

            public AuthService(IUserRepository userRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
            {
                _userRepository = userRepository;
                _customerRepository = customerRepository;
                _unitOfWork = unitOfWork;
                _configuration = configuration;
            }

            public async Task<AuthDTO> Authenticate(string gmail, string password)
            {
                var user = await _userRepository.FindByGmail(gmail);

                if (user == null)
                {
                    return null;
                }

                if (!AuthHelper.VerifyPassword(password, user.Password))
                {
                    return null;
                }


                var token = AuthHelper.BuildToken(
                    _configuration["Jwt:Internal:Key"], _configuration["Jwt:Internal:ValidIssuer"], user.Id, user.Gmail, user.Role.RoleName);

                return new AuthDTO
                {
                    AccessToken = token
                };

            }

            public async Task<AuthDTO> Authenticate(GoogleJsonWebSignature.Payload payload)
            {
                var customer = await _customerRepository.FindByGmail(payload.Email);

                if (customer == null)
                {
                    var id = payload.Email.Split("@")[0];
                    customer = new Customer
                    {
                        Id = id,
                        Gmail = payload.Email,
                        FullName = payload.GivenName,
                        Status = 1
                    };
                    await _customerRepository.Create(customer);
                    await _unitOfWork.SaveChangesAsync();
                }

                var token = AuthHelper.BuildToken(
                    _configuration["Jwt:Internal:Key"], _configuration["Jwt:Internal:ValidIssuer"], customer.Id, customer.Gmail, "Customer");

                return new AuthDTO
                {
                    AccessToken = token,
                };

            }
        }
    }
}
