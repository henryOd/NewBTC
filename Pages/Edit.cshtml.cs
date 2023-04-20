using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public EditModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InvestmentP InvestmentP { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InvestmentP == null)
            {
                return NotFound();
            }

            var investmentp =  await _context.InvestmentP.FirstOrDefaultAsync(m => m.Id == id);
            if (investmentp == null)
            {
                return NotFound();
            }
            InvestmentP = investmentp;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InvestmentP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentPExists(InvestmentP.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvestmentPExists(int id)
        {
          return _context.InvestmentP.Any(e => e.Id == id);
        }
    }
}
