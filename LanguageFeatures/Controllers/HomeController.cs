//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[] products = Product.GetProducts();
            
            return View(new string[] { products[2]?.Name ?? "No Value" });

            //return View(new string[] { products[2]!.Name });

            //string? val = products[2]?.Name;
            //if (val != null)
            //{
            //    return View(new string[] { val });
            //}
            //return View(new string[] { "No Value" });
        }
    }
}
