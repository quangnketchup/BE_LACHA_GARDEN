using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        public void InsertUser(User user) => UserDao.Instance.addNewUser(user);

        public void RemoveUser(string userId) => UserDao.Instance.Remove(userId);

        public void UpdateUser(User user) => UserDao.Instance.Update(user);

        public IEnumerable<User> GetFiltered(string tag) => UserDao.Instance.GetFilteredUser(tag);

        public User GetUserByID(string UserID) => UserDao.Instance.GetUserByID(UserID);

        public IEnumerable<User> GetUsers() => UserDao.Instance.getUserList();

        public async Task<User> GetUserByEmail(string email)
        => UserDao.Instance.GetUser(email);
    }
}