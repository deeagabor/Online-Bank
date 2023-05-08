using Bank.API.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.API.Repository.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        [MinLength(8)]
        public string? Password { get; set; }

        [Required]
        public bool Admin { get; set; }

        public ICollection<Account>? Accounts { get; set; } = new List<Account>();
    }
}
