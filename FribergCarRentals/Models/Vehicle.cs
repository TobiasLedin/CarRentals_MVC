using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Vehicle
    {
        [Key]
        [DisplayName("Vehicle ID")]
        public int VehicleId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [DisplayName("Marcus's comment")]
        public string? Comment { get; set; }
        [DisplayName("Image link")]
        public string? ImageUrl { get; set; }
     
    }
}
