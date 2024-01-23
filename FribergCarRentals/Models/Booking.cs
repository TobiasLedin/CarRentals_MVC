using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRentals.Models
{
    public class Booking
    {
        [Key]
        [DisplayName("Booking ID")]
        public int BookingId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Start date")]
        public DateTime BookingStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("End date")]
        public DateTime BookingEnd { get; set; }
        [Required]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Vehicle ID")]
        public int VehicleId { get; set; }

        public Customer Customer { get; set; }
        
        public Vehicle Vehicle { get; set; }

    }
}
