using Microsoft.AspNetCore.Mvc;

namespace IRS.Pages
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
