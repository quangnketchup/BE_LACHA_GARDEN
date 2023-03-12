using BussinessLayer.IRepository;
using LachaGarden.Models;

namespace LachaGarden.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        //private readonly ICustomerRepository _customerRepository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthDTO> Authenticate(string email, string password)
        {
            var user = await _userRepository.FindByGmail(email);

            if (user == null)
            {
                return null;
            }

            if (!AuthHelper.VerifyPassword(password, user.Password))
            {
                return null;
            }

            var token = AuthHelper.BuildToken(
                _configuration["Jwt:Internal:Key"], _configuration["Jwt:Internal:ValidIssuer"], user.Id, user.Gmail);

            return new AuthDTO
            {
                AccessToken = token
            };
        }

        //public async Task<AuthDTO> Authenticate(GoogleJsonWebSignature.Payload payload)
        //{
        //    var customer = await _customerRepository.FindByGmail(payload.Email);

        //    if (customer == null)
        //    {
        //        var id = payload.Email.Split("@")[0];
        //        customer = new Customer
        //        {
        //            Id = id,
        //            Gmail = payload.Email,
        //            Status = 1
        //        };
        //        await _customerRepository.Create(customer);
        //        await _unitOfWork.SaveChangesAsync();
        //    }

        //    var token = AuthHelper.BuildToken(
        //        _configuration["Jwt:Internal:Key"], _configuration["Jwt:Internal:ValidIssuer"], customer.Id, customer.Gmail, "Customer");

        //    return new AuthDTO
        //    {
        //        AccessToken = token,
        //    };

        //}
    }
}