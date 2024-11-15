using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saic.Models;
using Saic.Models.Repositories;
using System;
using System.Text.Json;

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
                .OrderBy(c => c.RespNome);

            return View(resps);
        }

        public ViewResult EditResp()
        {
            Guid? guid = null;

            ViewBag.EquipeList = new SelectList(
                    _equipeList,
                    "EquipeID",
                    "EquipeNome",
                    guid
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
                return NotFound();
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
                    existingResp.EquipeID = resp.EquipeID;;

                    _ctxResps.SaveRespCoop(existingResp);
                }
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
    }
}
