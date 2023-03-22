using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Accounts
{
    public class UserBalanceModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public UserBalanceModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; } = default!;
        public IList<Areas.Investment.Deposits> Deposits { get; set; }
        public IList<Areas.Investment.Withdraw>  Withdraws{ get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Account != null)
            {
                Account = await _context.Account.ToListAsync();
                Deposits = await _context.Deposits.ToListAsync();
                Withdraws = await _context.Withdraw.ToListAsync();
                Withdraw=await _context.Account.Select



                    

            }
        }
    }
}
