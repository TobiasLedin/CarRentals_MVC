using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Interfaces
{
    public interface IBookingRepository
    {
        void Create(Booking booking);
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        void Update(Booking booking);
        void Delete(int id);
    }
}
