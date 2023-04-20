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
    public class DeleteModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public DeleteModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InvestmentP == null)
            {
                return NotFound();
            }
            var investmentp = await _context.InvestmentP.FindAsync(id);

            if (investmentp != null)
            {
                InvestmentP = investmentp;
                _context.InvestmentP.Remove(InvestmentP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
