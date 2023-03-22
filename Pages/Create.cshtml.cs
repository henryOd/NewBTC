using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Pages
{
    public class CreateModel : PageModel
    {
        private readonly NewBTC.Data.ApplicationDbContext _context;

        public CreateModel(NewBTC.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //[BindProperty]
        //public List<SelectListItem> Duration { get; set; }
        
        //public string SelectedDuration { get; set; }
        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public InvestmentP InvestmentP { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                
                return Page();
            }
            InvestmentP.DateCreated = DateTime.Now.Date;
            InvestmentP.Email = User.Identity?.Name;

            _context.InvestmentP.Add(InvestmentP);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
