using FribergCarRentals.Data.Interfaces;
using FribergCarRentals.Models;

namespace FribergCarRentals.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public void Create(Booking booking)
        {
            try
            {
                _applicationDbContext.Bookings.Add(booking);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Delete(int id)
        {
            var booking = _applicationDbContext.Bookings.Find(id);
            try
            {
                _applicationDbContext.Bookings.Remove(booking);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public IEnumerable<Booking> GetAll()
        {
            IEnumerable<Booking> bookings;
            try
            {
                if (!_applicationDbContext.Bookings.Any())
                {
                    bookings = Enumerable.Empty<Booking>();
                }
                else
                {
                    bookings = _applicationDbContext.Bookings.ToList();
                }
                return bookings;
            }
            catch (Exception)
            {
                return null;    //TODO: Null-return
            }
        }

        public Booking GetById(int id)
        {
            if (!_applicationDbContext.Bookings.Any())
            {
                return null;
            }
            else
            {
                var booking = _applicationDbContext.Bookings.Find(id);  //TODO: Utvärdera Find, alt byt till FirstOrDefault().
                return booking;
            }
        }

        public void Update(Booking booking)
        {
            try
            {
                _applicationDbContext.Bookings.Update(booking);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
