using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingEnd { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }

    }
}
