namespace FribergCarRentals.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public bool Delivered { get; set; }
        public bool Returned { get; set; }

    }
}
