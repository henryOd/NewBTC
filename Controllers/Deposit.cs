using Microsoft.AspNetCore.Mvc;
using NewBTC.Areas.Investment;
using NewBTC.Data;
using NewBTC.Pages.Deposits;
using System.Diagnostics;

namespace NewBTC.Controllers
{

    public class Deposit : Controller
    {
        private readonly ApplicationDbContext _context;

        public IList<Deposits> Deposits { get; set; } = default!;
        public Deposit(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DepositList()
        {
            
            var deposits = _context.Deposits.Where(d => d.Name == User.Identity.Name).ToList();
            return PartialView("_DepositList", deposits);
        }

        public IActionResult DepositEdit(int id)
        {
            
            var deposit = _context.Deposits.Find(id);
            if (deposit != null)
            {
                return PartialView("_EditModal", deposit);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult CreateDeposit()
        {
            Deposits Depo = new Deposits();
            return PartialView("_AddDeposit", Depo);

        }
        [HttpPost]
        public IActionResult CreateDeposit(Deposits depo, decimal Amount)
        {
            depo.Name = User.Identity?.Name;
            depo.DateDeposited = DateTime.Now;
            var previousDeposit = _context.Deposits
                                .Where(d => d.Id == depo.Id)
                                .OrderByDescending(d => d.DateDeposited)
                                .FirstOrDefault();
            var previousBalance = previousDeposit != null ? previousDeposit.Balance : 0;

            Debug.WriteLine("Previous deposit: " + previousDeposit?.Amount);
            Debug.WriteLine("Previous balance: " + previousBalance);

            depo.Balance = previousBalance +  Amount;

            _context.Deposits.Add(depo);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Deposit added successfully.";
            return RedirectToPage("/Index");
        }

        [HttpPost]
        public IActionResult DepositEdit(Deposits deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Deposits.Update(deposit);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
