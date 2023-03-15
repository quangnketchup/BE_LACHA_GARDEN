using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    public class CustomerDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static CustomerDao instance = null;
        private static readonly object instanceLock = new object();

        private CustomerDao()
        {
        }

        public static CustomerDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Customer> getCustomerList()
        {
            List<Customer> FList = new List<Customer>();
            try
            {
                using var context = new lachagardenContext();
                var customers = context.Customers.Where(c => c.Status == 1).ToList();
                if (customers.Any())
                {
                    FList.AddRange(customers);
                }
                else
                {
                    FList = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Customer GetCustomerByID(string CustomerID)
        {
            Customer customer = null;
            try
            {
                using var context = new lachagardenContext();
                customer = context.Customers.SingleOrDefault(p => p.Id == CustomerID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return customer;
        }

        //-----------------------
        public void addNewCustomer(Customer customer)
        {
            try
            {
                Customer customers = GetCustomerByID(customer.Id);
                if (customers == null)
                {
                    using var context = new lachagardenContext();
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Customer customer)
        {
            try
            {
                Customer customers = GetCustomerByID(customer.Id);
                if (customers != null)
                {
                    using var context = new lachagardenContext();
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(string customerId)
        {
            try
            {
                Customer customers = GetCustomerByID(customerId);
                if (customers != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Customer gardenPack = db.Customers.Where(d => d.Id == customerId).First();
                        gardenPack.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Customer> GetFilteredCustomer(String tag)
        {
            List<Customer> filtered = new List<Customer>();
            foreach (Customer customer in getCustomerList())
            {
                int add = 0;
                if (customer.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(customer);
            }
            return filtered;
        }

        public Customer GetCustomer(string email)
        {
            Customer customer = null;
            try
            {
                using var context = new lachagardenContext();
                customer = context.Customers.SingleOrDefault(a => a.Gmail.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
    }
}