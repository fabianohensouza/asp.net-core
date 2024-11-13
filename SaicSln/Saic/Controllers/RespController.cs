using Microsoft.AspNetCore.Mvc;
using Saic.Models;
using Saic.Models.Repositories;
using Saic.Models.ViewModels;

namespace Saic.Controllers
{
    public class RespController : Controller
    {
        private IRespRepository repository;

        public RespController(IRespRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.RespCoops);

        public ViewResult AddResp() => View(new RespCoop());

        [HttpPost]
        public IActionResult AddResp(RespCoop resp)
        {
            if (resp.RespNome == "")
            {
                ModelState.AddModelError("", "Favor informar o nome");
            }

            if (ModelState.IsValid)
            {
                repository.CreateRespCoop(resp);
                return RedirectToPage("/AddedResp", new { respId = resp.RespID });
            }
            else
            {
                return View();
            }
        }
    }
}
