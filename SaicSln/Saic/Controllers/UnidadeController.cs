using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.Repositories;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class UnidadeController : Controller
    {
        private IUnidadeRepository _ctxUnidades;
        private ICoopRepository _ctxCoops;

        public UnidadeController(IUnidadeRepository unidade, ICoopRepository coop)
        {
            _ctxUnidades = unidade;
            _ctxCoops = coop;
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

            var coop = _ctxCoops.Coops
                .Where(c => c.CoopID == coopID)
                .FirstOrDefault();

            return View(new UnidadesListViewModel
            {
                Unidades = unidades,
                CoopAtual = coop
            });
        }

        [HttpPost]
        [Route("Unidade/EditUnidade")]
        [ValidateAntiForgeryToken]
        public IActionResult EditUnidade(Guid coopID, Guid? unidadeID = null)
        {
            if (unidadeID == null)
            {
                var novaUnidade = new Unidade();

                novaUnidade.Coop = _ctxCoops.Coops
                .Where(c => c.CoopID == coopID)
                .FirstOrDefault();

                novaUnidade.CoopID = coopID;
                novaUnidade.UnidadeNova = true;

                return View (novaUnidade);
            }

            var unidade = _ctxUnidades.Unidades
                .Include(c => c.Coop)
                .Include(c => c.Firewalls)
                    .ThenInclude(c => c.Fabricante)
                .Include(c => c.Links)
                    .ThenInclude(t => t.TipoLink)
                .Include(c => c.Vlans)
                .Where(c => c.UnidadeID == unidadeID)
                .Where(c => c.CoopID == coopID)
                .FirstOrDefault();
            
            return View(unidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Unidade unidade)
        {
            if (ModelState.IsValid)
            {
                var existingUnidade = _ctxUnidades.Unidades
                    .Where(c => c.UnidadeID == unidade.UnidadeID)
                    .FirstOrDefault();

                if (existingUnidade != null)
                {
                    existingUnidade.UnidadeNumero = unidade.UnidadeNumero;
                    existingUnidade.UnidadeNome = unidade.UnidadeNome;
                    existingUnidade.UnidadeObs = unidade.UnidadeObs;

                    bool isSaved = _ctxUnidades.SaveUnidade(existingUnidade);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Unidade alterada com sucesso!" : "Erro ao alterar Unidade!";

                    return RedirectToAction("Index", "Unidade", new { CoopID = unidade.CoopID });
                }

                bool isCreated = _ctxUnidades.CreateUnidade(unidade);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Unidade criada com sucesso!" : "Erro ao criar Unidade!";

                return RedirectToAction("Index", "Unidade", new { CoopID = unidade.CoopID });
            }

            return RedirectToAction("EditUnidade", new { 
                CoopID = unidade.CoopID,
                UnidadeID = unidade.UnidadeID
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUnidade(Guid? coopID, Guid UnidadeID)
        {
            var existingUnidade = _ctxUnidades.Unidades
                .Where(c => c.UnidadeID == UnidadeID)
                .FirstOrDefault();

            if (existingUnidade == null)
            {
                TempData["ErrorMessage"] = "Unidade não encontrada!";
                return RedirectToAction("Index", "Unidade", new { CoopID = coopID });
            }

            bool isDeleted = _ctxUnidades.DeleteUnidade(existingUnidade);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Unidade removida com sucesso!" : "Erro ao remover o Unidade!";

            return RedirectToAction("Index", "Unidade", new { CoopID = coopID });
        }
    }
}
