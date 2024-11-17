using Microsoft.AspNetCore.Mvc;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;

namespace Saic.Controllers
{
    public class UnidadeController : Controller
    {
        private IUnidadeRepository _ctxUnidades;
        private readonly StoreDbContext _context;
        private readonly IList<Equipe> _equipeList;

        public UnidadeController(IUnidadeRepository repo, StoreDbContext context)
        {
            _ctxUnidades = repo;
            _context = context;
            _equipeList = _context.Equipes
                .OrderBy(e => e.EquipeNome)
                .ToList();
        }

        public IActionResult Index(Guid? coopID)
        {
            if (coopID == null)
            {
                TempData["ErrorMessage"] = "Unidades não encontradas!";
                return RedirectToAction("Index", "Home");
            }

            var unidades = _ctxUnidades.Unidades
                .Where(c => c.CoopID == coopID)
                .OrderBy(c => c.UnidadeNumero);

            foreach (var resp in unidades)
            {
                //resp.QtdCoops = resp.Coops.Count;
                //resp.QtdCompts = resp.Coops.Sum(c => c.QtdCompts ?? 0);
            }

            return View(unidades);
        }
    }
}
