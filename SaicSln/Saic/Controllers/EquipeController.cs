using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.AuxiliarModels;

namespace Saic.Controllers
{
    public class EquipeController : Controller
    {
        private readonly StoreDbContext _context;

        public EquipeController(StoreDbContext context) => _context = context;

        public IActionResult Index()
        {
            var equipeRespsList = _context.Equipes
                .Include(r => r.RespCoops)
                .ToList();

            return View(equipeRespsList);
        
        }
    }
}
