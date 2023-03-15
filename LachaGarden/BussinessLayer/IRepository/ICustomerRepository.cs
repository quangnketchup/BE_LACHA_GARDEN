using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByEmail(string email);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomerByID(string CustomerID);

        IEnumerable<Customer> GetFiltered(string tag);

        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void RemoveCustomer(string customerId);
    }
}