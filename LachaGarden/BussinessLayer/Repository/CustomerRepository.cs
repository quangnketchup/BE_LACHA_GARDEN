using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly lachagardenContext _context;

        public CustomerRepository(lachagardenContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _context.AddAsync(customer);
            return customer;
        }

        public async Task<Customer> FindByGmail(string Gmail)
        {
            return await _context.Customers
                .SingleOrDefaultAsync(x => x.Gmail == Gmail);
        }

        public async Task<Customer> Get(string id)
        {
            return await _context.Customers
                .SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }
    }
}