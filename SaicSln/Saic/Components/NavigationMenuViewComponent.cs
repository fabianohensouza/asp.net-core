using Microsoft.AspNetCore.Mvc;
using Saic.Models.ViewModels;

namespace Saic.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedMenu = RouteData?.Values["controller"];

            return View(
                new NavigationMenuInfo[]{
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Home",
                        Label = "Coops",
                        Icone = "fa-solid fa-building-columns" },
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Resp",
                        Label = "Responsáveis",
                        Icone = "fa-solid fa-briefcase" },
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Equipe",
                        Label = "Equipe",
                        Icone = "fa-solid fa-people-group" },
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Unidade",
                        Label = "Unidades",
                        Icone = "fa-solid fa-map-location-dot" },
                    new NavigationMenuInfo{ 
                        Action = "Index", 
                        Controller = "Painel", 
                        Label = "Painel" ,
                        Icone = "fa-solid fa-list-check"},
                    new NavigationMenuInfo{ 
                        Action = "Index", 
                        Controller = "Servidor", 
                        Label = "Servidores" ,
                        Icone = "fa-solid fa-server"},
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Firewall",
                        Label = "Firewalls" ,
                        Icone = "fa-solid fa-shield-halved"},
                    new NavigationMenuInfo{
                        Action = "Index",
                        Controller = "Equipamento",
                        Label = "Equipamentos" ,
                        Icone = "fa-solid fa-network-wired"},
                    new NavigationMenuInfo{ 
                        Action = "Index", 
                        Controller = "Servico", 
                        Label = "Serviços" ,
                        Icone = "fa-solid fa-globe"}
                }.AsEnumerable() 
            );
        }
    }
}
