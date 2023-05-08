using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bank.API.Repository.Entities
{
    public class Account
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

        [Range(0, float.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public float Sum { get; set; }

        [Required]
        public int UserId { get; set; }

        public ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    }
}
