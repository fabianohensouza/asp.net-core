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

        public ViewResult Index(int coopPage = 1) => View(new CoopsListViewModel
        {
            Coops = repository.Coops
                .OrderBy(c => c.CoopID)
                .Skip((coopPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                PagAtual = coopPage,
                ItemsPorPag = PageSize,
                TotalItens = repository.Coops.Count()
            }
        });
    }
}
