using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly lachagardenContext _context;

        public UserRepository(lachagardenContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.AddAsync(user);
            return user;
        }

        public async Task<User> FindByGmail(string Gmail)
        {
            return await _context.Users
                .SingleOrDefaultAsync(x => x.Gmail == Gmail);
        }

        public async Task<User> Get(string id)
        {
            return await _context.Users
                .Include(q => q.Role).SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}