using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Repositories
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext _applicationsDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationsDbContext = applicationDbContext;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _applicationsDbContext.Bookings.OrderBy(a => a.BookingId);
        }

        public Booking GetById(int id)
        {
            return _applicationsDbContext.Bookings.FirstOrDefault(x => x.BookingId == id);
        }
    }
}
