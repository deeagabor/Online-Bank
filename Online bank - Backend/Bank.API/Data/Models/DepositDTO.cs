namespace Bank.API.Data.Models
{
    public class DepositDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Period { get; set; }
        public float DepositSum { get; set; }
    }
}
