using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;

namespace Saic.Controllers
{
    public class FirewallController : Controller
    {
        private IFirewallRepository _ctxFirewall;
        private readonly StoreDbContext _context;
        private readonly IList<Fabricante> _fabricanteList;

        public FirewallController(IFirewallRepository repo, StoreDbContext context)
        {
            _ctxFirewall = repo;
            _context = context;
            _fabricanteList = _context.Fabricantes
                .OrderBy(e => e.FabricanteNome)
                .ToList();
        }

        public ViewResult Index()
        {
            var firewalls = _ctxFirewall.Firewalls
                .Include(f => f.Fabricante)
                .Include(u => u.Unidade)
                .Where(f => f.Fabricante.FabricanteTipo == "Firewall");

            return View(firewalls);
        }

        public ViewResult Editfirewall()
        {
            ViewBag.EquipeList = new SelectList(
                    _fabricanteList,
                    "EquipeID",
                    "FabricanteNome"
                );

            return View(new Firewall());
        }

        [HttpPost]
        public IActionResult Editfirewall(Guid firewallId)
        {
            var firewall = _ctxFirewall.Firewalls
                .Where(c => c.FirewallID == firewallId)
                .FirstOrDefault();

            if (firewall == null)
            {
                TempData["ErrorMessage"] = "firewallonsável não encontrado!";
                return RedirectToAction("Index", "firewall");
            }

            ViewBag.EquipeList = new SelectList(
                _fabricanteList,
                "EquipeID",
                "FabricanteNome",
                firewall.FirewallID
            );

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

                    bool isSaved = _ctxFirewall.SaveFirewall(existingfirewall);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "firewallonsável alterado com sucesso!" : "Erro ao alterar firewallonsável!";

                    return RedirectToAction("Index", "firewall");
                }

                bool isCreated = _ctxFirewall.CreateFirewall(firewall);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "firewallonsável criado com sucesso!" : "Erro ao criar firewallonsável!";

                return RedirectToAction("Index", "firewall");
            }

            ViewBag.EquipeList = new SelectList(
                _fabricanteList,
                "EquipeID",
                "FabricanteNome",
                firewall.FabricanteID
            );

            return View("Index", firewall);
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
                TempData["ErrorMessage"] = "firewallonsável não encontrado!";
                return RedirectToAction("Index", "firewall");
            }

            bool isDeleted = _ctxFirewall.DeleteFirewall(firewall);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "firewallonsável removido com sucesso!" : "Erro ao remover o firewallonsável!";

            return RedirectToAction("Index", "firewall");
        }
    }
}
