using Microsoft.AspNetCore.Mvc;
using Saic.Models.ViewModels;

namespace Saic.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(
                new NavigationMenuInfo[]{
                    new NavigationMenuInfo{ 
                        Action = "index", 
                        Controller = "unidades",
                        Label = "Unidades",
                        Icone = "fa-solid fa-map-location-dot" },
                    new NavigationMenuInfo{ 
                        Action = "index", 
                        Controller = "painel", 
                        Label = "Painel" ,
                        Icone = "fa-solid fa-list-check"},
                    new NavigationMenuInfo{ 
                        Action = "index", 
                        Controller = "servidores", 
                        Label = "Servidores" ,
                        Icone = "fa-solid fa-server"},
                    new NavigationMenuInfo{ 
                        Action = "index", 
                        Controller = "equipamentos", 
                        Label = "Equipamentos" ,
                        Icone = "fa-solid fa-network-wired"},
                    new NavigationMenuInfo{ 
                        Action = "index", 
                        Controller = "servicos", 
                        Label = "Serviços" ,
                        Icone = "fa-solid fa-globe"}
                }.AsEnumerable() 
            );
        }
    }
}
