using System.ComponentModel.DataAnnotations;


namespace Bank.API.Data.Models
{
    public class AccountUpdateDTO
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }


        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public float Sum { get; set; }
        public int UserId { get; set; }
    }
}
