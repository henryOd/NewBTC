using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages.Deposits
{
    public class CreateModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CreateModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Areas.Investment.Deposits Deposits { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid )
            {
                
                return Page();

            }

            
                // Create a new account if one doesn't already exist for the deposit
                //var existingAccount = _context.Account.FirstOrDefault(a => a.UserName==Deposits.Name);
                //if (existingAccount == null)
                //{
                //    existingAccount = new Account
                //    {
                //        UserName = User.Identity?.Name,
                //        UserBalance = Deposits.Amount,
                //        ActionAmount = Deposits.Amount,
                //        Actiondate = DateTime.Now,
                //        ActionTaken = "Deposit"

                //    };

                //    _context.Account.Add(existingAccount);

                //}
                //else
                //{
                //    existingAccount.UserBalance += Deposits.Amount;
                //    _context.Account.Update(existingAccount);
                //}

                // Add the new deposit record
                //Deposits.Account = existingAccount;
            Deposits.Name = User.Identity?.Name;
            Deposits.DateDeposited = DateTime.Now;
            _context.Deposits.Add(Deposits);
                await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
    }
}
