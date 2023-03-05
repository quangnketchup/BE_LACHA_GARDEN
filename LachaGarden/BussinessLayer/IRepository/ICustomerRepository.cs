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
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int customerID);
        IEnumerable<Customer> GetFiltered(string tag);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(int customerId);
    }
}
