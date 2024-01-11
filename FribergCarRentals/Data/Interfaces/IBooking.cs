using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
    }
}
