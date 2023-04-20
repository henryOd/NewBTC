using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewBTC.Pages
{
    public class NewBTCindexModel : PageModel
    {
        [AllowAnonymous]
        public void OnGet()
        {
        }
    }
}
