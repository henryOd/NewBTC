using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public IndexModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InvestmentP> InvestmentP { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.InvestmentP != null)
            {
                InvestmentP = await _context.InvestmentP.ToListAsync();
            }
        }
    }
}
