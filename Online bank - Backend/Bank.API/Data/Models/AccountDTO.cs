namespace Bank.API.Data.Models
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Sum { get; set; }

        public int UserId { get; set; }

        public int NumberOfDeposits
        {
            get
            {
                return Deposits.Count;
            }
        }

        public ICollection<DepositDTO> Deposits { get; set; } = new List<DepositDTO>();
    }
}
