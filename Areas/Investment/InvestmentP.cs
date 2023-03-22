using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBTC.Areas.Investment
{
    public class InvestmentP
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public PlanType Duration { get; set; }  
        public decimal Amount { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal MiniInvestment { get; set; }
        public decimal MaxInvestment { get; set; }
    }

    public enum PlanType
    {
       Starter, 
       Gold,
       Premium,
       Exlusive
    }
}
