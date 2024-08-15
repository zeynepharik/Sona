
using System.ComponentModel.DataAnnotations;

namespace SONA.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required]
        [StringLength(50)]
        public string? RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }


        public RoomType? RoomType { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>(); 
        [Required]
        public bool IsAvailable { get; set; }

        public bool IsDelete { get; set; }

       
    }
}
