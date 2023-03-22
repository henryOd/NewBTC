using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Withdraw
{
    public class DetailsModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public DetailsModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public NewBTC.Areas.Investment.Withdraw Withdraw { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Withdraw == null)
            {
                return NotFound();
            }

            var withdraw = await _context.Withdraw.FirstOrDefaultAsync(m => m.Id == id);
            if (withdraw == null)
            {
                return NotFound();
            }
            else 
            {
                Withdraw = withdraw;
            }
            return Page();
        }
    }
}
