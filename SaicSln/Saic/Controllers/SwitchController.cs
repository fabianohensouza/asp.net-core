using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;
using Saic.Models.ViewModels;
using System.Net;

namespace Saic.Controllers
{
    public class SwitchController : Controller
    {
        private ISwitchRepository _ctxSwitch;
        private readonly StoreDbContext _context;
        private readonly IList<Fabricante> _fabricanteList;
        private readonly IList<Coop> _coopList;

        public SwitchController(ISwitchRepository repo, StoreDbContext context)
        {
            _ctxSwitch = repo;
            _context = context;
            _fabricanteList = _context.Fabricantes
                .Where(f => f.FabricanteTipo == "Switch")
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

            var SwitchesList =  _ctxSwitch.Switches
                    .Include(f => f.Fabricante)
                    .Include(u => u.Unidade)
                    .Include(c => c.Coop)
                    .ToList();

            return View(SwitchesList);
        }

        [HttpPost]
        public ViewResult ListSwitches(Guid coopID)
        {
            var SwitchesList = new SwitchesListViewModel
            {
                Switches = _ctxSwitch.Switches
                    .Include(f => f.Fabricante)
                    .Include(u => u.Unidade)
                    .Include(c => c.Coop)
                    .Where(c => c.Coop.CoopID == coopID)
                    .ToList(),
                CoopAtual = _coopList.FirstOrDefault(c => c.CoopID == coopID)
            };                

            return View(SwitchesList);
        }

        [HttpPost]
        public IActionResult EditSwitch(Guid? coopID, Guid? SwitchID = null)
        {
            if (coopID == null)
            {
                TempData["ErrorMessage"] = "Unidades não encontradas!";
                return RedirectToAction("Index", "Home");
            }

            var Switch = new Switch();

            Switch.Coop = _coopList.FirstOrDefault(c => c.CoopID == coopID);
            Switch.CoopID = coopID;
            LoadViewBags(Switch);

            if (SwitchID == null)
            {
                return View(Switch);
            }

            Switch = _ctxSwitch.Switches
                .Where(c => c.SwitchID == SwitchID)
                .FirstOrDefault();

            if (Switch == null)
            {
                TempData["ErrorMessage"] = "Switch não encontrado!";
                return View("RedirectToPost", coopID);
            }

            return View(Switch);
        }

        [HttpPost]
        public IActionResult ReloadSwitch(Switch Switch)
        {
            if (Switch?.CoopID == null)
            {
                return NotFound(); // Handle user not found
            }

            Switch.Coop = _coopList.FirstOrDefault(c => c.CoopID == Switch.CoopID);
            LoadViewBags(Switch);
            return View("EditSwitch", Switch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Switch Switch)
        {
            if (ModelState.IsValid)
            {
                Switch.LastChange = DateTime.Now;

                Switch.SwitchSerial = Switch.SwitchSerial?.ToUpper();

                if (Switch.SwitchBackup)
                {
                    Switch.UnidadeID = null;
                    Switch.Unidade = null;
                }

                var existingSwitch = _ctxSwitch.Switches
                    .Where(c => c.SwitchID == Switch.SwitchID)
                    .FirstOrDefault();

                if (existingSwitch != null)
                {
                    existingSwitch.SwitchModelo = Switch.SwitchModelo;
                    existingSwitch.SwitchBackup = Switch.SwitchBackup;
                    existingSwitch.UnidadeID = Switch.UnidadeID;
                    existingSwitch.CoopID = Switch.CoopID;
                    existingSwitch.SwitchSerial = Switch.SwitchSerial?.ToUpper();
                    existingSwitch.FabricanteID = Switch.FabricanteID;
                    existingSwitch.SwitchAcesso = Switch.SwitchAcesso;
                    existingSwitch.SwitchPortas = Switch.SwitchPortas;
                    existingSwitch.SwitchObs = Switch.SwitchObs;
                    existingSwitch.LastChange = Switch.LastChange;

                    bool isSaved = _ctxSwitch.SaveSwitch(existingSwitch);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Switch alterado com sucesso!" : "Erro ao alterar Switch!";

                    return View("RedirectToPost", Switch.CoopID);
                }

                bool isCreated = _ctxSwitch.CreateSwitch(Switch);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Switch criado com sucesso!" : "Erro ao criar Switch!";

                return View("RedirectToPost", Switch.CoopID);
            }

            return ReloadSwitch(Switch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSwitch(Guid SwitchId)
        {
            var Switch = _ctxSwitch.Switches
                .Where(c => c.SwitchID == SwitchId)
                .FirstOrDefault();

            if (Switch == null)
            {
                TempData["ErrorMessage"] = "Switch não encontrado!";
                return RedirectToAction("Index", "Switch");
            }

            bool isDeleted = _ctxSwitch.DeleteSwitch(Switch);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Switch removido com sucesso!" : "Erro ao remover o Switch!";

            return View("RedirectToPost", Switch.CoopID);
        }

        private void LoadViewBags(Switch Switch)
        {
            ViewBag.CoopList = Switch.Coop.DisplayName;

            ViewBag.FabricanteList = new SelectList(
                _fabricanteList,
                "FabricanteID",
                "FabricanteNome",
                Switch.FabricanteID
            );

            ViewBag.UnidadeList = new SelectList(
                _context.Unidades
                    .Where(c => c.CoopID == Switch.CoopID)
                    .OrderBy(e => e.UnidadeNumero)
                    .ToList(),
                "UnidadeID",
                "UnidadeNumero",
                Switch.UnidadeID
            );
        }
    }
}
