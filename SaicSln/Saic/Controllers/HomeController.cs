using Microsoft.AspNetCore.Mvc;

namespace Saic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
