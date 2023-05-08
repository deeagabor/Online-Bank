using System.ComponentModel.DataAnnotations;

namespace Bank.API.Data.Models
{
    public class UserCreationDTO
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }


        [Required]
        public bool Admin { get; set; }
    }
}
