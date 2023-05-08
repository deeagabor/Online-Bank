using Bank.API.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Bank.API.Data.Models
{
    public class DepositCreationDTO
    {
        [Required(ErrorMessage = "You should provide a name value!")]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [DepositPeriod(ErrorMessage = "The period must be 1,6 or 12 months.")]
        public int Period { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public float DepositSum { get; set; }
    }
}
