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
          if (!ModelState.IsValid || _context.Deposits == null || Deposits == null)
            {
                
                return Page();

            }
             
            Deposits.Name = User.Identity?.Name;
            Deposits.DateDeposited = DateTime.Now;
            _context.Deposits.Add(Deposits);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
     
    }
}
