using Microsoft.AspNetCore.Mvc;
using Saic.Models.Repositories;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class HomeController : Controller
    {
        private ICoopRepository repository;
        public int PageSize = 10;

        public HomeController(ICoopRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string? coopSelecionada, int coopPage = 1) => View(new CoopsListViewModel
        {
            ListaCoops = repository.Coops
                .Select(c => c.CoopNumero)
                .Distinct()
                .ToList(),
            Coops = repository.Coops
                .Where(c => coopSelecionada == null || c.CoopNumero == coopSelecionada)
                .OrderBy(c => c.CoopID)
                .Skip((coopPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PagAtual = coopPage,
                ItemsPorPag = PageSize,
                TotalItens = coopSelecionada == null 
                    ? repository.Coops.Count()
                    : repository.Coops.Where (c => c.CoopNumero == coopSelecionada).Count()
            },
            CoopAtual = coopSelecionada
        });
    }
}
