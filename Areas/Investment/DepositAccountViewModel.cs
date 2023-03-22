namespace NewBTC.Areas.Investment
{
    public class DepositAccountViewModel
    {
        public class UpdateOrderViewModel
        {
            public int DespositId { get; set; }
            public string? UserName { get; set; }
            public decimal DepositAmount { get; set; }
            public int AccountId { get; set; }
            public string? ActionTaken { get; set; }
            public decimal AccountBalance { get; set; }
            public decimal TotalBalance { get; set; }

        }
    }
}
