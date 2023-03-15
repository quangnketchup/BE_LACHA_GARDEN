using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void InsertCustomer(Customer customer) => CustomerDao.Instance.addNewCustomer(customer);

        public void RemoveCustomer(string customerId) => CustomerDao.Instance.Remove(customerId);

        public void UpdateCustomer(Customer customer) => CustomerDao.Instance.Update(customer);

        public IEnumerable<Customer> GetFiltered(string tag) => CustomerDao.Instance.GetFilteredCustomer(tag);

        public Customer GetCustomerByID(string CustomerID) => CustomerDao.Instance.GetCustomerByID(CustomerID);

        public IEnumerable<Customer> GetCustomers() => CustomerDao.Instance.getCustomerList();

        public async Task<Customer> GetCustomerByEmail(string email)
        => CustomerDao.Instance.GetCustomer(email);
    }
}