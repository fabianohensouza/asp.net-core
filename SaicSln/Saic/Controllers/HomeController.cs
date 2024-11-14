using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saic.Models.Repositories;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class HomeController : Controller
    {
        private ICoopRepository _ctxCoops;
        private IRespRepository _ctxResps;
        public int PageSize = 10;

        public HomeController(ICoopRepository coops, IRespRepository resps)
        {
            _ctxCoops = coops;
            _ctxResps = resps;
        }

        public ViewResult Index(string? RespSelecionado, int coopPage = 1) => View(new CoopsListViewModel
        {
            ListaResps = _ctxResps.RespCoops
                .Select(c => c.RespNome)
                .Distinct()
                .ToList(),
            Coops =_ctxCoops.Coops
                .Include(r => r.RespCoop)
                .Where(c => RespSelecionado == null || c.RespCoop.RespNome == RespSelecionado)
                .OrderBy(c => c.CoopNumero)
                .Skip((coopPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PagAtual = coopPage,
                ItemsPorPag = PageSize,
                TotalItens = RespSelecionado == null 
                    ?_ctxCoops.Coops.Count()
                    :_ctxCoops.Coops.Where (c => c.CoopNumero == RespSelecionado).Count()
            },
            RespAtual = RespSelecionado
        });
    }
}
