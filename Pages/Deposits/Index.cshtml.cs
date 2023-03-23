using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Deposits
{
    public class IndexModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public IndexModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Areas.Investment.Deposits> Deposits { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Deposits != null)
            {
                Deposits = await _context.Deposits.ToListAsync();

            }
        }
    }
}
