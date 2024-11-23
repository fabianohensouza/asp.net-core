using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class VlanController : Controller
    {
        private IVlanRepository _ctxVlans;
        private readonly StoreDbContext _context;

        public VlanController(IVlanRepository repo, StoreDbContext context)
        {
            _ctxVlans = repo;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditVlan(Guid unidadeID, Guid? vlanID = null)
        {
            var unidadeList = _context.Unidades
                .Include(c => c.Coop)
                .OrderBy(e => e.UnidadeNumero)
                .ToList();

            if (vlanID == null)
            {
                var novaVlan = new Vlan();

                novaVlan.UnidadeID = unidadeID;
                novaVlan.Unidade = _context.Unidades
                    .Include (c => c.Coop)
                    .Where(u => u.UnidadeID == unidadeID)
                    .FirstOrDefault();

                return View(novaVlan);
            }

            var vlan = _ctxVlans.Vlans
                .Include(u => u.Unidade)
                    .ThenInclude(c => c.Coop)
                .Where(l => l.VlanID == vlanID)
                .FirstOrDefault();

            return View(vlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Vlan vlan)
        {
            if (ModelState.IsValid)
            {
                var unidade = _context.Unidades
                    .Where(c => c.UnidadeID == vlan.UnidadeID)
                    .FirstOrDefault();

                var existingVlan = _ctxVlans.Vlans
                    .Include(u => u.Unidade)
                    .Where(c => c.VlanID == vlan.VlanID)
                    .FirstOrDefault();

                if (unidade.CoopID == Guid.Empty || unidade.UnidadeID == Guid.Empty)
                {
                    TempData["ErrorMessage"] = "Erro ao localizar a Vlan!";
                    return View("Index", "Home");
                }

                var unidadeModel = new UnidadePostModel
                {
                    CoopID = unidade.CoopID,
                    UnidadeID = unidade.UnidadeID
                };

                if (existingVlan != null)
                {
                    existingVlan.VlanTag = vlan.VlanTag;
                    existingVlan.VlanNome = vlan.VlanNome;
                    existingVlan.VlanRangeIP = vlan.VlanRangeIP;
                    existingVlan.VlanObs = vlan.VlanObs;

                    bool isSaved = _ctxVlans.SaveVlan(existingVlan);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Vlan alterada com sucesso!" : "Erro ao alterar Vlan!";

                    return View("RedirectToPost", unidadeModel);
                }

                bool isCreated = _ctxVlans.CreateVlan(vlan);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Vlan criada com sucesso!" : "Erro ao criar Vlan!";

                return View("RedirectToPost", unidadeModel);
            }

            return View("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVlan(Guid vlanID)
        {
            var link = _ctxVlans.Vlans
                    .Where(c => c.VlanID == vlanID)
                    .FirstOrDefault();

            if (link == null)
            {
                TempData["ErrorMessage"] = "Vlan não encontrada!";
                return RedirectToAction("Index", "Home");
            }

            var unidade = _context.Unidades
                    .Where(c => c.UnidadeID == link.UnidadeID)
                    .FirstOrDefault();

            var unidadeModel = new UnidadePostModel
            {
                CoopID = unidade.CoopID,
                UnidadeID = unidade.UnidadeID
            };

            bool isDeleted = _ctxVlans.DeleteVlan(link);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Vlan removida com sucesso!" : "Erro ao remover a Vlan!";

            return View("RedirectToPost", unidadeModel);
        }
    }
}
