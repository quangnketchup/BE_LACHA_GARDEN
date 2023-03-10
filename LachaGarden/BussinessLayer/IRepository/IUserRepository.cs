using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
