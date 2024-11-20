using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;
using Saic.Models.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Saic.Controllers
{
    public class FirewallController : Controller
    {
        private IFirewallRepository _ctxFirewall;
        private readonly StoreDbContext _context;
        private readonly IList<Fabricante> _fabricanteList;
        private readonly IList<Coop> _coopList;

        public FirewallController(IFirewallRepository repo, StoreDbContext context)
        {
            _ctxFirewall = repo;
            _context = context;
            _fabricanteList = _context.Fabricantes
                .Where(f => f.FabricanteTipo == "Firewall")
                .OrderBy(e => e.FabricanteNome)
                .ToList();
            _coopList = _context.Coops
                .OrderBy(e => e.CoopNumero)
                .ToList();
        }

        public ViewResult Index()
        {
            ViewBag.CoopList = new SelectList(
                    _coopList,
                    "CoopID",
                    "DisplayName"
                );

            return View();
        }

        [HttpPost]
        public ViewResult ListFirewalls(Guid coopID)
        {
            var firewallsList = new FirewallsListViewModel
            {
                Firewalls = _ctxFirewall.Firewalls
                    .Include(f => f.Fabricante)
                    .Include(u => u.Unidade)
                    .Include(c => c.Coop)
                    .Where(c => c.Coop.CoopID == coopID),
                CoopAtual = _coopList.FirstOrDefault(c => c.CoopID == coopID)
            };                

            return View(firewallsList);
        }

        [HttpPost]
        public IActionResult EditFirewall(Guid? coopID, Guid? firewallID = null)
        {
            if (coopID == null)
            {
                TempData["ErrorMessage"] = "Unidades não encontradas!";
                return RedirectToAction("Index", "Home");
            }

            var firewall = new Firewall();

            firewall.Coop = _coopList.FirstOrDefault(c => c.CoopID == coopID);
            firewall.CoopID = coopID;

            ViewBag.CoopList = firewall.Coop.DisplayName;

            ViewBag.FabricanteList = new SelectList(
                _fabricanteList,
                "FabricanteID",
                "FabricanteNome",
                firewall.FabricanteID
            );

            ViewBag.UnidadeList = new SelectList(
                _context.Unidades
                    .Where(c => c.CoopID == coopID)
                    .OrderBy(e => e.UnidadeNumero)
                    .ToList(),
                "UnidadeID",
                "UnidadeNumero",
                firewall.UnidadeID
            );

            if (firewallID == null)
            {
                return View(firewall);
            }

            firewall = _ctxFirewall.Firewalls
                .Where(c => c.FirewallID == firewallID)
                .FirstOrDefault();

            if (firewall == null)
            {
                TempData["ErrorMessage"] = "Firewall não encontrado!";
                return RedirectToAction("ListFirewalls", "Firewall", new { CoopID = coopID });
            }

            return View(firewall);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Firewall firewall)
        {
            if (ModelState.IsValid)
            {
                var existingfirewall = _ctxFirewall.Firewalls
                    .Where(c => c.FirewallID == firewall.FirewallID)
                    .FirstOrDefault();

                if (existingfirewall != null)
                {
                    if (firewall.FirewallBackup)
                    {
                        firewall.UnidadeID = null;
                        firewall.Unidade = null;
                    }

                    bool isSaved = _ctxFirewall.SaveFirewall(existingfirewall);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Firewall alterado com sucesso!" : "Erro ao alterar Firewall!";

                    return RedirectToAction("ListFirewalls", "Firewall", new { CoopID = firewall.CoopID });
                }

                bool isCreated = _ctxFirewall.CreateFirewall(firewall);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Firewall criado com sucesso!" : "Erro ao criar Firewall!";

                return RedirectToAction("ListFirewalls", "Firewall", new { CoopID = firewall.CoopID });
            }

            TempData["ErrorMessage"] = "Erro nos dados inseridos!";
            return RedirectToAction("ListFirewalls", "Firewall", new { CoopID = firewall.CoopID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletefirewall(Guid firewallId)
        {
            var firewall = _ctxFirewall.Firewalls
                .Where(c => c.FirewallID == firewallId)
                .FirstOrDefault();

            if (firewall == null)
            {
                TempData["ErrorMessage"] = "Firewall não encontrado!";
                return RedirectToAction("Index", "firewall");
            }

            bool isDeleted = _ctxFirewall.DeleteFirewall(firewall);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Firewall removido com sucesso!" : "Erro ao remover o Firewall!";

            return RedirectToAction("Index", "firewall");
        }
    }
}
