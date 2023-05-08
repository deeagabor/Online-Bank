using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Bank.API.Utilities;

namespace Bank.API.Repository.Entities
{
    public class Deposit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [DepositPeriodAttribute(ErrorMessage ="The period must be 1,6 or 12 months.")]
        public int Period { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public float DepositSum { get; set; }

        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
        public int AccountId { get; set; }
    }
}
