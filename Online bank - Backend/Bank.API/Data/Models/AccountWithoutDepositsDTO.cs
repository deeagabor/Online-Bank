namespace Bank.API.Data.Models
{
    public class AccountWithoutDepositsDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Sum { get; set; }
        public int UserId { get; set; }
    }
}
