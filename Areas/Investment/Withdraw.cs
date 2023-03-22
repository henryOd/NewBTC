namespace NewBTC.Areas.Investment
{
    public class Withdraw
    {
        public int Id { get; set; }
        public string? Username  { get; set; }
        public decimal withdrawAmount { get; set; }
        public DateTime WithdrawDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AcctBalance { get; set; }
        public withdrawStatus Wstatus { get; set; }

    }

    public enum withdrawStatus
    {
        pending, 
        processing,
        success
    }
}
