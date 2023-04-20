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

namespace NewBTC.Pages.Deposits
{


    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public DetailsModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Areas.Investment.Deposits Deposits { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposits = await _context.Deposits.FirstOrDefaultAsync(m => m.Id == id);
            if (deposits == null)
            {
                return NotFound();
            }
            else 
            {
                Deposits = deposits;
            }
            return Page();
        }
    }
}
