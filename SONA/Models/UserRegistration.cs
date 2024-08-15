using System.ComponentModel.DataAnnotations;

namespace SONA.Models
{
    public class UserRegistration
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
        public string Username { get; set; } 

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "E-posta adresi en fazla 100 karakter olabilir.")]
        public string Email { get; set; } 

        [Required]
        [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
        public string PhoneNumber { get; set; } 

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır.")]
        public string Password { get; set; } 
    }
}
