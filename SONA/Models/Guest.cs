using SONA.Models;
using System.ComponentModel.DataAnnotations;

namespace SONA.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public string? UserId { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
