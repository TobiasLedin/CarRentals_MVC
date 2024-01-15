using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public int Year { get; set; }
        public double DailyRate { get; set; }
     
    }
}
