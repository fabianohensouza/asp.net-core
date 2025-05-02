using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using System.Net;

namespace Saic.Controllers
{
    public class RespController : Controller
    {
        private IRespRepository _ctxResps;
        private readonly StoreDbContext _context;

        public RespController(IRespRepository repo, StoreDbContext context)
        {
            _ctxResps = repo;
            //_context = context;
        }

        public ViewResult Index()
        {
            var resps = _ctxResps.RespCoops
                .Include(r => r.Coops)
                    .ThenInclude(f => f.Firewalls)
                .Include(r => r.Coops)
                    .ThenInclude(s => s.Servidores)
                .OrderBy(c => c.RespNome);

            foreach (var resp in resps)
            {
                resp.QtdCoops = resp.ReturnCoops();
                resp.QtdCompts = resp.ReturnCompts();
            }

            return View(resps);
        }

        [HttpPost]
        public IActionResult EditResp(Guid? respId = null)
        {
            if (respId == null)
            {
                return View(new RespCoop());
            }

            var existingResp = _ctxResps.RespCoops
                .Where(c => c.RespID == respId)
                .FirstOrDefault();

            if (existingResp == null)
            {
                TempData["ErrorMessage"] = "Responsável não encontrado!";
                return RedirectToAction("Index", "Resp");
            }

            return View(existingResp);
        }

        [HttpPost]
        public IActionResult ReloadResp(RespCoop resp)
        {
            if (resp?.RespID == null)
            {
                return NotFound(); // Handle user not found
            }

            return View("EditResp", resp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(RespCoop resp)
        {
            if (ModelState.IsValid)
            {
                resp.LastChange = DateTime.Now;

                var existingResp = _ctxResps.RespCoops
                    .Where(c => c.RespID == resp.RespID)
                    .FirstOrDefault();

                if (existingResp != null)
                {
                    existingResp.RespNome = resp.RespNome;
                    existingResp.LastChange = resp.LastChange;

                    bool isSaved = _ctxResps.SaveRespCoop(existingResp);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Responsável alterado com sucesso!" : "Erro ao alterar responsável!";

                    return RedirectToAction("Index", "Resp");
                }

                bool isCreated = _ctxResps.CreateRespCoop(resp);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Responsável criado com sucesso!" : "Erro ao criar responsável!";

                return RedirectToAction("Index", "Resp");
            }

            return ReloadResp(resp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteResp(Guid respId)
        {
            var resp = _ctxResps.RespCoops
                .Where(c => c.RespID == respId)
                .FirstOrDefault();

            if (resp == null)
            {
                TempData["ErrorMessage"] = "Responsável não encontrado!";
                return RedirectToAction("Index", "Resp");
            }

            bool isDeleted = _ctxResps.DeleteRespCoop(resp);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Responsável removido com sucesso!" : "Erro ao remover o responsável!";

            return RedirectToAction("Index", "Resp");
        }

        //private void LoadViewBags()
        //{
        //    ViewBag.EquipeList = new SelectList(
        //            _equipeList,
        //            "EquipeID",
        //            "EquipeNome"
        //    );
        //}
    }
}

