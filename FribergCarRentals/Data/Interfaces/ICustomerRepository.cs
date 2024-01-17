using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        void Update(Customer customer);
        void Delete(int id);

    }
}
