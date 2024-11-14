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

        public ViewResult EditResp(Guid? respId = null) => View(new RespCoop());

        [HttpPost]
        public IActionResult EditResp(RespCoop resp)
        {
            if (resp.RespNome == "")
            {
                ModelState.AddModelError("", "Favor informar o nome");
            }

            if (ModelState.IsValid)
            {
                repository.CreateRespCoop(resp);
                return RedirectToPage("/Resp", new { respId = resp.RespID });
            }
            else
            {
                return View();
            }
        }
    }
}
