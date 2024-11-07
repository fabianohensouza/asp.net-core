using Microsoft.AspNetCore.Mvc;

namespace Saic.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(
                new []{
                    new { action = "index", controller = "unidades", label = "Unidades" },
                    new { action = "index", controller = "painel", label = "Painel" },
                    new { action = "index", controller = "servidores", label = "Servidores" },
                    new { action = "index", controller = "equipamentos", label = "Equipamentos" },
                    new { action = "index", controller = "servicos", label = "Serviços" }
                }.AsEnumerable() 
            );
        }
    }
}
