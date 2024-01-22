using Microsoft.Build.Graph;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Lastname")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
