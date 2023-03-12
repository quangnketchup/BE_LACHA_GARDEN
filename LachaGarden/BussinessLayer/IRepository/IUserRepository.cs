using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IUserRepository
    {
        Task<User> Get(string id);

        Task<User> FindByGmail(string Gmail);

        Task<User> Create(User user);

        Task Update(User user);
    }
}