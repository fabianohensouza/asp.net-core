using Microsoft.AspNetCore.Mvc;
using Saic.Models.Repositories;
using System.Text.Json;

namespace Saic.Controllers
{
    public class EditCoopController : Controller
    {
        private ICoopRepository repository;

        public EditCoopController(ICoopRepository repo)
        {
            repository = repo;
        }

        [HttpPost]
        public IActionResult Index(Guid coopID)
        {
            var coop = repository.Coops
                .Where(c => c.CoopID == coopID).
                FirstOrDefault();

            ViewData["ObjectData"] = JsonSerializer.Serialize(
                coop, new JsonSerializerOptions { WriteIndented = true }
            );

            return View(coop);
        }
    }
}
