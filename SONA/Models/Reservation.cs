using SONA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }

    [Required]
    public int GuestId { get; set; }

    [ForeignKey(nameof(GuestId))]
    public Guest? Guest { get; set; }

    [Required]
    public int RoomId { get; set; }

    [ForeignKey(nameof(RoomId))]
    public Room? Room { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    [Required]
    [Range(1, 3)]
    public int NumberOfGuests { get; set; }

    public int? PaymentId { get; set; }  
    public Payment? Payment { get; set; }  

    public decimal TotalPrice { get; set; }

    public bool IsStatus { get; set; }

    public bool IsDelete { get; set; }
}
