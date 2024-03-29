﻿using Microsoft.AspNetCore.Authorization;

namespace NewBTC.Areas.Investment
{
    [Authorize]
    public class Account
    {
        public int AccountId { get; set; }
        public string? UserName { get; set; }
        public decimal UserBalance { get; set; }
        public DateTime Actiondate { get; set; }
        public string? ActionTaken { get; set; }
        public decimal ActionAmount { get; set; }
    }
}
