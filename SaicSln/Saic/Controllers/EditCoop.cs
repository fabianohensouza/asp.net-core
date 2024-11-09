using Microsoft.AspNetCore.Mvc;

namespace Saic.Controllers
{
    public class EditCoop : Controller
    {
        public IActionResult Index(long coopID)
        {
            return View();
        }
    }
}
