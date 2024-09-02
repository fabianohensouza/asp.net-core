using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Saic.Models;
using Saic.Models.Repositories;

namespace Saic.Controllers
{
    public class HomeController : Controller
    {
        private ICoopRepository repository;

        public HomeController(ICoopRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Coops);
    }
}
