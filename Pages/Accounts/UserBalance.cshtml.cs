using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Investment;
using Microsoft.AspNetCore.Identity;

using NewBTC.Data;

namespace NewBTC.Pages.Accounts
{
    public class UserBalanceModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;
       // private readonly UserManager<ApplicationUser> _userManager;

        public UserBalanceModel( NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
             //_userManager = userManager;
        }
            public IList<Areas.Investment.Withdraw>  Withdraws{ get; set; }

        public IList<Areas.Investment.Deposits> Deposits { get; set; } = default!;
        public IList<Areas.Investment.Account> Account { get; set; } = default!;

        public async Task  OnGetAsync(string username)
        {
            if (_context.Deposits != null || _context.Withdraw !=null)
            {

                // var currentUser = _userManager.GetUserAsync(User).Result;
                //Deposits=  _context.Deposits.Where(u => u.Name == currentUser.UserName).ToList();
              Account =await _context.Deposits
                .Select(d => new Account
                {
                    AccountId = d.Id,
                    UserName = d.Name,
                    ActionAmount = d.Amount,
                    Actiondate = d.DateDeposited,
                    ActionTaken = "Deposit"
                })
                .Union(_context.Withdraw
                .Select(w => new Account
                {
                    AccountId = w.Id,
                    UserName = w.Username,
                    ActionAmount = -w.withdrawAmount,
                    Actiondate = w.WithdrawDate,
                    ActionTaken = "Withdraw"
                }))
                .ToListAsync();

                //if (!string.IsNullOrEmpty(username))
                //{
                //    transactions = transactions.Where(t => t.UserName == username).ToList();
                //}
                

                //var viewModel = new DepositAccountViewModel
                //{
                //    Transactions = transactions
                //};
                

            }

          

        }
    }
}

