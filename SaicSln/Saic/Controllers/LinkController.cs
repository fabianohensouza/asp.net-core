using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saic.Models.AuxiliarModels;
using Saic.Models.Repositories;
using Saic.Models;
using Microsoft.EntityFrameworkCore;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class LinkController : Controller
    {
        private ILinkRepository _ctxLinks;
        private readonly StoreDbContext _context;
        private readonly IList<TipoLink> _tipoLinksList;

        public LinkController(ILinkRepository repo, StoreDbContext context)
        {
            _ctxLinks = repo;
            _context = context;
            _tipoLinksList = _context.TipoAuxiliares
                .ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLink(Guid unidadeID, Guid? linkID = null)
        {
            var unidadeList = _context.Unidades
                .Include(c => c.Coop)
                .OrderBy(e => e.UnidadeNumero)
                .ToList();

            ViewBag.TipoLinkList = new SelectList(
                _tipoLinksList,
                "TipoLinkID",
                "TipoLinkNome"
            );

            if (linkID == null)
            {
                var novoLink = new Link();

                novoLink.UnidadeID = unidadeID;
                novoLink.Unidade = unidadeList
                    .Where(c => c.UnidadeID == unidadeID)
                    .FirstOrDefault();

                return View(novoLink);
            }

            var link = _ctxLinks.Links
                .Include(u => u.Unidade)
                    .ThenInclude(c => c.Coop)
                .Where(l => l.LinkID == linkID)
                .FirstOrDefault();

            return View(link);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Link link)
        {
            if (ModelState.IsValid)
            {
                link.LastChange = DateTime.Now;

                var unidade =  _context.Unidades
                    .Where(c => c.UnidadeID == link.UnidadeID)
                    .FirstOrDefault();

                var existinLink = _ctxLinks.Links
                    .Include (u => u.Unidade)
                    .Where(c => c.LinkID == link.LinkID)
                    .FirstOrDefault();

                if (unidade.CoopID == Guid.Empty || unidade.UnidadeID == Guid.Empty)
                {
                    TempData["ErrorMessage"] = "Erro ao localizar a Unidade!";
                    return View("Index", "Home");
                }

                var unidadeModel = new UnidadePostModel
                {
                    CoopID = unidade.CoopID,
                    UnidadeID = unidade.UnidadeID
                };

                if (existinLink != null)
                {
                    existinLink.TipoLinkID = link.TipoLinkID;
                    existinLink.LinkProvedor = link.LinkProvedor;
                    existinLink.LinkIP = link.LinkIP;
                    existinLink.LastChange = link.LastChange;

                    bool isSaved = _ctxLinks.SaveLink(existinLink);
                    TempData[isSaved ? "SuccessMessage" : "ErrorMessage"]
                        = isSaved ? "Link alterado com sucesso!" : "Erro ao alterar Link!";

                    return View("RedirectToPost", unidadeModel);
                }

                bool isCreated = _ctxLinks.CreateLink(link);
                TempData[isCreated ? "SuccessMessage" : "ErrorMessage"]
                    = isCreated ? "Link criado com sucesso!" : "Erro ao criar Link!";

                return View("RedirectToPost", unidadeModel);
            }

            return View("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletelink(Guid linkId)
        {
            var link = _ctxLinks.Links
                .Where(c => c.LinkID == linkId)
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

            bool isDeleted = _ctxLinks.DeleteLink(link);

            TempData[isDeleted ? "SuccessMessage" : "ErrorMessage"]
                = isDeleted ? "Vlan removida com sucesso!" : "Erro ao remover a Vlan!";

            return View("RedirectToPost", unidadeModel);
        }
    }
}
