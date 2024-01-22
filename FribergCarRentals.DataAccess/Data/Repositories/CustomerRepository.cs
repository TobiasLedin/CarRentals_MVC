using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Create(Customer customer)
        {
            try
            {
                _applicationDbContext.Customers.Add(customer);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }

        }

        public void Delete(int id)
        {
            var customer = _applicationDbContext.Customers.Find(id);
            try
            {
                _applicationDbContext.Customers.Remove(customer);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> customers;
            try
            {
                if (!_applicationDbContext.Customers.Any())
                {
                    customers = Enumerable.Empty<Customer>();
                }
                else
                {
                    customers = _applicationDbContext.Customers.ToList();
                }
                return customers;
            }
            catch (Exception)
            {
                return null;    //TODO: Null-return
            }
        }

        public Customer GetById(int id)
        {
            if (!_applicationDbContext.Customers.Any())
            {
                return null;
            }
            else
            {
                var customer = _applicationDbContext.Customers.Find(id);  //TODO: Utvärdera Find, alt byt till FirstOrDefault().
                return customer;
            }

        }

        public void Update(Customer customer)
        {
            try
            {
                _applicationDbContext.Customers.Update(customer);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
