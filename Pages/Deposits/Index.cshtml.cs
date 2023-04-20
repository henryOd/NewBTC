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
using Newtonsoft.Json;

namespace NewBTC.Pages.Deposits
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public IndexModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Areas.Investment.Deposits> Deposits { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Deposits != null)
            {
                Deposits = await _context.Deposits.ToListAsync();

            }
        }

        public async Task<IActionResult> OnGetDepositListAsync()
        {
            var IndexModel = new IndexModel(_context);
            var EditModel = new EditModel(_context);

            var viewModel = new DepositViewModel
            {
                IndexModel = IndexModel,
                EditModel = EditModel
            };
            Deposits = await _context.Deposits.ToListAsync();
            ViewData["Deposits"] = Deposits;
            var jsonViewModel = JsonConvert.SerializeObject(viewModel);
            return new PartialViewResult
            {
                ViewName = "_DepositList",
                ViewData = ViewData
            };


        }
    }
}
