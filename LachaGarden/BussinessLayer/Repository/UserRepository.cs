using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Include(q => q.Role)
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
