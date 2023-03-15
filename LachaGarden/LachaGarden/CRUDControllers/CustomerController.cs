using BusinessLayer.Models;
using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> Get()
        {
            var customerList = customerRepository.GetCustomers();
            return Ok(customerList);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get(string id)
        {
            var customer = customerRepository.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer/create
        [HttpPost("create"), Authorize]
        public async Task<ActionResult> Post([FromBody] CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer
                {
                    FullName = customer.FullName,
                    Phone = customer.Phone,
                    Gmail = customer.Gmail,
                    Gender = customer.Gender,
                    Password = customer.Password,
                    Status = 1,
                };

                customerRepository.InsertCustomer(newCustomer);
                return CreatedAtAction(nameof(Get), new { id = newCustomer.Id }, newCustomer);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Customer/edit/5
        [HttpPut("edit/{id}"), Authorize]
        public ActionResult Put(string id, [FromBody] CustomerDTO customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Customer updateCustomer = new Customer
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    Phone = customer.Phone,
                    Gmail = customer.Gmail,
                    Gender = customer.Gender,
                    Password = customer.Password,
                    Status = 1,
                };
                customerRepository.UpdateCustomer(updateCustomer);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/Customer/delete/5
        [HttpPost("delete/{id}"), Authorize]
        public ActionResult Delete(string id)
        {
            var customer = customerRepository.GetCustomerByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            customerRepository.RemoveCustomer(id);
            return Ok("Delete successful");
        }

        // GET: api/Customer/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Customer>> Search(string name)
        {
            var customer = customerRepository.GetCustomers();
            var result = customer;

            if (name != null)
            {
                result = customer.Where(p => p.FullName.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(result);
        }
    }
}