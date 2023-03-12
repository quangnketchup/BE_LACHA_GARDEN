using DataAccessLayer.Models;

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