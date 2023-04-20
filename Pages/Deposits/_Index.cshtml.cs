using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Deposits
{
    public class _IndexModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public _IndexModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NewBTC.Areas.Investment.Deposits> Deposit { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    if (_context.Deposits != null)
        //    {
        //        Deposit = await _context.Deposits.ToListAsync();
        //    }
        //}

        //public PartialViewResult OnGet_Index()
        //{
        //    if (_context.Deposits != null)
        //    {
        //        Deposit = _context.Deposits.ToList();
        //    }
        //    return new PartialViewResult
        //    {
        //        ViewName = "_Index",
        //        ViewData = new ViewDataDictionary<List<NewBTC.Areas.Investment.Deposits>>(ViewData, Deposit)
        //    };
        //}

        //public IActionResult OnGetPartial() => Partial("_Index");

       
    }
}
