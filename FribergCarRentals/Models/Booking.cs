using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingEnd { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
