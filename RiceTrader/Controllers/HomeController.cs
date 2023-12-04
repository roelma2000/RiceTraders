using Microsoft.AspNetCore.Mvc;

namespace RiceTrader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
