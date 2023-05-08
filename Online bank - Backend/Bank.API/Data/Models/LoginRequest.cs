using System.ComponentModel.DataAnnotations;

namespace Bank.API.Data.Models
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
    }
}

