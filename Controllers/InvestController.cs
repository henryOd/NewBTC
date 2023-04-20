using Microsoft.AspNetCore.Mvc;
using NewBTC.Areas.Investment;
using NewBTC.Data;

namespace NewBTC.Controllers
{
    public class InvestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IList<InvestmentP> Invest { get; set; } = default!;
        public InvestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DepositList()
        {

            var invest = _context.InvestmentP.Where(d => d.Email == User.Identity.Name).ToList();
            return PartialView("_InvestList", invest);
        }

        public IActionResult CreateInvest()
        {
            InvestmentP Investo= new InvestmentP();
            return PartialView("_AddInvest", Investo);

        }
        [HttpPost]
        public IActionResult CreateInvest(InvestmentP Investo)
        {
            Investo.Email = User.Identity?.Name;
            Investo.DateCreated = DateTime.Now.Date;
            _context.InvestmentP.Add(Investo);
            _context.SaveChanges();
            //TempData["SuccessMessage"] = "Deposit added successfully.";

            return RedirectToPage("./Index");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

    }
}
