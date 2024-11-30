using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models;
using Saic.Models.Repositories;

namespace Saic.Controllers
{
    public class EditCoopController : Controller
    {
        private ICoopRepository _ctxCoops;
        private IRespRepository _ctxResps;

        public EditCoopController(ICoopRepository coops, IRespRepository resps)
        {
            _ctxCoops = coops;
            _ctxResps = resps;
        }

        [HttpPost]
        public IActionResult Index(Guid coopID)
        {
            var coop = _ctxCoops.Coops
                .Where(c => c.CoopID == coopID)
                .FirstOrDefault();

            if (coop == null)
            {
                TempData["ErrorMessage"] = "Coop não encontrada!";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.RespCoopList = new SelectList(
                _ctxResps.RespCoops.ToList(), 
                "RespID", 
                "RespNome", 
                coop.RespID
            );

            return View(coop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Coop coop)
        {
            if (ModelState.IsValid)
            {
                var existingCoop = _ctxCoops.Coops
                    .Where(c => c.CoopID == coop.CoopID)
                    .FirstOrDefault();

                if (existingCoop != null)
                {
                    existingCoop.Adesao = coop.Adesao;
                    existingCoop.QtdCompts = coop.QtdCompts;
                    existingCoop.RespID = coop.RespID;
                    existingCoop.LastChange = DateTime.Now;

                    bool isSaved = _ctxCoops.SaveCoop(existingCoop);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Coop alterada com sucesso!" : "Erro ao alterar coop!";
                }
                return RedirectToAction("Index", "Home");
            }

            ViewBag.RespCoopList = new SelectList(_ctxResps.RespCoops, "RespID", "RespNome", coop.RespID);
            return View("Index", coop);
        }
    }
}
