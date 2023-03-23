using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Withdraw
{
    public class CreateModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public CreateModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewBTC.Areas.Investment.Withdraw Withdraw { get; set; } = default!;
        public NewBTC.Areas.Investment.InvestmentP investment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Withdraw == null || Withdraw == null)
            {
                return Page();
            }
            Withdraw.Username = User.Identity?.Name;
            Withdraw.WithdrawDate = DateTime.Now;
 
            _context.Withdraw.Add(Withdraw);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
