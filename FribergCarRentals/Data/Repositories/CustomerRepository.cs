using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _applicationDbContext.Customers.OrderBy(x => x.CustomerId);
        }

        public Customer GetById(int id)
        {
            return _applicationDbContext.Customers.FirstOrDefault(x => x.CustomerId == id);
        }
    }
}
