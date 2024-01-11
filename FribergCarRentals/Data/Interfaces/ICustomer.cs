using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface ICustomer
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();

    }
}
