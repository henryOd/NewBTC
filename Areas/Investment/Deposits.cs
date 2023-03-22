namespace NewBTC.Areas.Investment
{
    public class Deposits
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateDeposited { get; set; }
        public Status status { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

    }

    public enum Status
    {
        Pending,
        Processing, 
        Comfirmed
    }
}
