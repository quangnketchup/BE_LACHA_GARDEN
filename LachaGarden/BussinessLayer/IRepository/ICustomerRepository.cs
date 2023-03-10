using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(string id);
        Task<Customer> FindByGmail(string Gmail);
        Task<Customer> Create(Customer customer);
        Task Update(Customer customer);
    }
}
