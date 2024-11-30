﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class ServidorController : Controller
    {
        private IServidorRepository _ctxServidor;
        private readonly StoreDbContext _context;
        private readonly IList<Coop> _coopList;

        public ServidorController(IServidorRepository repo, StoreDbContext context)
        {
            _ctxServidor = repo;
            _context = context;
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

            var servidoresList = _ctxServidor.Servidores
                    .Include(f => f.Fabricante)
                    .Include(u => u.Unidade)
                    .Include(c => c.Coop)
                    .Include(s => s.SistOp)
                    .ToList();

            return View(servidoresList);
        }

        [HttpPost]
        public ViewResult ListServidores(Guid coopID)
        {
            var servidoresList = new ServidoresListViewModel
            {
                Servidores = _ctxServidor.Servidores
                    .Include(f => f.Fabricante)
                    .Include(u => u.Unidade)
                    .Include(c => c.Coop)
                    .Include(s => s.SistOp)
                    .Where(c => c.Coop.CoopID == coopID)
                    .ToList(),

                CoopAtual = _coopList.FirstOrDefault(c => c.CoopID == coopID)
            };

            return View(servidoresList);
        }

        [HttpPost]
        public IActionResult EditServidor(Guid coopID, Guid? servidorID = null)
        {
            var servidor = new Servidor();

            servidor.Coop = _coopList.FirstOrDefault(c => c.CoopID == coopID);
            servidor.CoopID = coopID;

            ViewBag.CoopList = servidor.Coop.DisplayName;

            ViewBag.UnidadeList = new SelectList(
                _context.Unidades
                    .Where(c => c.CoopID == coopID)
                    .OrderBy(e => e.UnidadeNumero)
                    .ToList(),
                "UnidadeID",
                "UnidadeNumero",
                servidor.UnidadeID
            );

            ViewBag.FabricanteList = new SelectList(
                _context.Fabricantes
                    .Where(f => f.FabricanteTipo == "Servidor")
                    .OrderBy(e => e.FabricanteNome)
                    .ToList(),
                "FabricanteID",
                "FabricanteNome",
                servidor.FabricanteID
            );

            ViewBag.SistOpList = new SelectList(
                _context.SistOps
                    .OrderBy(e => e.SistOpID)
                    .ToList(),
                "SistOpID",
                "SistOpNome",
                servidor.SistOpID
            );

            if (servidorID == null)
            {
                return View(servidor);
            }

            servidor = _ctxServidor.Servidores
                .Where(c => c.ServidorID == servidorID)
                .FirstOrDefault();

            if (servidor == null)
            {
                TempData["ErrorMessage"] = "Servidor não encontrado!";
                return View("RedirectToPost", coopID);
            }

            return View(servidor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                servidor.ServidorSerial = servidor.ServidorSerial.ToUpper();
                servidor.LastChange = DateTime.Now;

                if (servidor.ServidorVirtual)
                {
                    servidor.ServidorGarantia = null;
                    servidor.FabricanteID = null;
                    servidor.ServidorCPU = null;
                    servidor.ServidorIDrac = null;
                    servidor.ServidorSerial = null;
                    servidor.ServidorModelo = "Virtual";
                }

                var existingservidor = _ctxServidor.Servidores
                    .Where(c => c.ServidorID == servidor.ServidorID)
                    .FirstOrDefault();

                if (existingservidor != null)
                {
                    existingservidor.ServidorNome = servidor.ServidorNome;
                    existingservidor.ServidorModelo = servidor.ServidorModelo;
                    existingservidor.ServidorSerial = servidor.ServidorSerial;
                    existingservidor.ServidorVirtual = servidor.ServidorVirtual;
                    existingservidor.ServidorCPU = servidor.ServidorCPU;
                    existingservidor.ServidorRAM = servidor.ServidorRAM;
                    existingservidor.ServidorIP = servidor.ServidorIP;
                    existingservidor.ServidorIDrac = servidor.ServidorIDrac;
                    existingservidor.ServidorAcesso = servidor.ServidorAcesso;
                    existingservidor.ServidorGarantia = servidor.ServidorGarantia;
                    existingservidor.UnidadeID = servidor.UnidadeID;
                    existingservidor.CoopID = servidor.CoopID;
                    existingservidor.FabricanteID = servidor.FabricanteID;
                    existingservidor.ServidorObs = servidor.ServidorObs;
                    existingservidor.LastChange = servidor.LastChange;

                    bool isSaved = _ctxServidor.SaveServidor(existingservidor);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "servidor alterado com sucesso!" : "Erro ao alterar servidor!";

                    return View("RedirectToPost", servidor.CoopID);
                }

                bool isCreated = _ctxServidor.CreateServidor(servidor);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "servidor criado com sucesso!" : "Erro ao criar servidor!";

                return View("RedirectToPost", servidor.CoopID);
            }

            TempData["ErrorMessage"] = "Erro nos dados inseridos!";
            return View("RedirectToPost", servidor.CoopID);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServidor(Guid servidorId)
        {
            var servidor = _ctxServidor.Servidores
                .Where(c => c.ServidorID == servidorId)
                .FirstOrDefault();

            if (servidor == null)
            {
                TempData["ErrorMessage"] = "servidor não encontrado!";
                return RedirectToAction("Index", "Servidor");
            }

            bool isDeleted = _ctxServidor.DeleteServidor(servidor);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "servidor removido com sucesso!" : "Erro ao remover o servidor!";

            return View("RedirectToPost", servidor.CoopID);
        }
    }
}
