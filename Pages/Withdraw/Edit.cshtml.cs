using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Withdraw
{
    public class EditModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public EditModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NewBTC.Areas.Investment.Withdraw Withdraw { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Withdraw == null)
            {
                return NotFound();
            }

            var withdraw =  await _context.Withdraw.FirstOrDefaultAsync(m => m.Id == id);
            if (withdraw == null)
            {
                return NotFound();
            }
            Withdraw = withdraw;
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

            _context.Attach(Withdraw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WithdrawExists(Withdraw.Id))
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

        private bool WithdrawExists(int id)
        {
          return (_context.Withdraw?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
