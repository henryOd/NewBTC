using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext 
_context;

        public DetailsModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public InvestmentP InvestmentP { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InvestmentP == null)
            {
                return NotFound();
            }

            var investmentp = await _context.InvestmentP.FirstOrDefaultAsync(m => m.Id == id);
            if (investmentp == null)
            {
                return NotFound();
            }
            else 
            {
                InvestmentP = investmentp;
            }
            return Page();
        }
    }
}
