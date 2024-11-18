using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.Repositories;

namespace Saic.Controllers
{
    public class UnidadeController : Controller
    {
        private IUnidadeRepository _ctxUnidades;

        public UnidadeController(IUnidadeRepository repo)
        {
            _ctxUnidades = repo;
        }

        public IActionResult Index(Guid? coopID)
        {
            if (coopID == null)
            {
                TempData["ErrorMessage"] = "Unidades não encontradas!";
                return RedirectToAction("Index", "Home");
            }

            var unidades = _ctxUnidades.Unidades
                .Include(c => c.Coop)
                .Where(c => c.CoopID == coopID)
                .OrderBy(c => c.UnidadeNumero);

            return View(unidades);
        }

        public IActionResult EditUnidade(Guid? coopID, Guid? unidadeID = null)
        {
            if (coopID == null)
            {
                TempData["ErrorMessage"] = "Unidades não encontradas!";
                return RedirectToAction("Index", "Home");
            }

            if(unidadeID == null)
            {
                var novaUnidade = new Unidade();
                novaUnidade.CoopID = coopID;

                return View (novaUnidade);
            }

            var unidade = _ctxUnidades.Unidades
                .Include(c => c.Coop)
                .Include(c => c.Firewalls)
                .Include(c => c.Links)
                .Where(c => c.UnidadeID == unidadeID)
                .Where(c => c.CoopID == coopID);

            return View(unidade);
        }
    }
}
