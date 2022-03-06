using Microsoft.AspNetCore.Mvc;

namespace Magadi.Services.Identity.MainModule
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Siemasss");
        }
    }
}
