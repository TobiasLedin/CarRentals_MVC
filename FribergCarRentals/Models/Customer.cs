using Microsoft.Build.Graph;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }

    }
}
