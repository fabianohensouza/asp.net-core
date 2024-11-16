using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;

namespace Saic.Controllers
{
    public class RespController : Controller
    {
        private IRespRepository _ctxResps;
        private readonly StoreDbContext _context;
        private readonly IList<Equipe> _equipeList;

        public RespController(IRespRepository repo, StoreDbContext context)
        {
            _ctxResps = repo;
            _context = context;
            _equipeList = _context.Equipes
                .OrderBy(e => e.EquipeNome)
                .ToList();
        }

        public ViewResult Index()
        {
            var resps = _ctxResps.RespCoops
                .Include(r => r.Equipe)
                .Include(r => r.Coops)
                .OrderBy(c => c.RespNome);

            foreach (var resp in resps)
            {
                resp.QtdCoops = resp.Coops.Count;
                resp.QtdCompts = resp.Coops.Sum(c => c.QtdCompts ?? 0);
                resp.QtdFwlls = resp.Coops.Sum(c => c.QtdFwlls ?? 0);
                resp.QtdServers = resp.Coops.Sum(c => c.QtdServers ?? 0);
            }

            return View(resps);
        }

        public ViewResult EditResp()
        {
            ViewBag.EquipeList = new SelectList(
                    _equipeList,
                    "EquipeID",
                    "EquipeNome"                    
                );

            return View(new RespCoop());
        }

        [HttpPost]
        public IActionResult EditResp(Guid respId)
        {
            var resp = _ctxResps.RespCoops
                .Where(c => c.RespID == respId)
                .FirstOrDefault();

            if (resp == null)
            {
                TempData["ErrorMessage"] = "Responsável não encontrado!";
                return RedirectToAction("Index", "Resp");
            }

            ViewBag.EquipeList = new SelectList(
                _equipeList,
                "EquipeID",
                "EquipeNome",
                resp.EquipeID
            );

            return View(resp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(RespCoop resp)
        {
            if (ModelState.IsValid)
            {
                var existingResp = _ctxResps.RespCoops
                    .Where(c => c.RespID == resp.RespID)
                    .FirstOrDefault();

                if (existingResp != null)
                {
                    existingResp.RespNome = resp.RespNome;
                    existingResp.EquipeID = resp.EquipeID; ;

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

            ViewBag.EquipeList = new SelectList(
                _equipeList,
                "EquipeID",
                "EquipeNome",
                resp.EquipeID
            );

            return View("Index", resp);
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
    }
}
