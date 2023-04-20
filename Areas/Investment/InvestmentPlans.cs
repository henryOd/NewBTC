using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBTC.Areas.Invesment
{
    [Authorize]
    public class InvestmentPlan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SelectedDuration { get; set; }
        [NotMapped]
        public List<SelectListItem>? Duration { get; set; }

        public decimal Amount { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal MiniInvestment { get; set; }
        public decimal MaxInvestment { get; set; }

    }

}
