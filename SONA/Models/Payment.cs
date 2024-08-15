using SONA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }

    public int? GuestId { get; set; }

    [ForeignKey("GuestId")]
    public Guest? Guest { get; set; }

    [Required]
    public int ReservationId { get; set; }

    [ForeignKey("ReservationId")]
    public Reservation? Reservation { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    public bool IsSuccessful { get; set; }

    public bool IsPaidAtHotel { get; set; } = false;

    public bool IsDelete { get; set; }
}
