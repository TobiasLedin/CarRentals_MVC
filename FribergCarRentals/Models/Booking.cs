using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRentals.Models
{
    public class Booking
    {
        [Key]
        [DisplayName("Vehicle ID")]
        public int BookingId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Vehicle ID")]
        public DateTime BookingStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingEnd { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int VehicleId { get; set; }

        public Customer Customer { get; set; }
        
        public Vehicle Vehicle { get; set; }

    }
}
