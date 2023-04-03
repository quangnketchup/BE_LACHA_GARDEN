using BussinessLayer.Dao;
using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);

        IEnumerable<User> GetUsers();

        IEnumerable<User> GetTechnicals();

        User GetUserByID(string UserID);

        IEnumerable<User> GetFiltered(string tag);

        void InsertUser(User user);

        void UpdateUser(User user);

        void RemoveUser(string userId);
    }
}