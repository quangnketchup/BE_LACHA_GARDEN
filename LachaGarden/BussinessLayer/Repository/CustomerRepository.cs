using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetFiltered(string tag) => CustomerDao.Instance.GetFilteredCustomer(tag);

        public Customer GetCustomerByID(int customerID) => CustomerDao.Instance.GetCustomerByID(customerID);

        public IEnumerable<Customer> GetCustomers() => CustomerDao.Instance.getCustomerList();

        public void InsertCustomer(Customer customer) => CustomerDao.Instance.addNewCustomer(customer);

        public void RemoveCustomer(int customerId) => CustomerDao.Instance.Remove(customerId);

        public void UpdateCustomer(Customer customer) => CustomerDao.Instance.Update(customer);
    }
}
