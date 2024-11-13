using Microsoft.AspNetCore.Mvc;

namespace Saic.Controllers
{
    public class EditCoopController : Controller
    {
        public IActionResult Index(long coopID)
        {
            return View();
        }
    }
}
