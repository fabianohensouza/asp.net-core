//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            return View("Index", new string[] { $"Array Total: {arrayTotal:C2}" });

            //return View(new string[] {
            //    $"Name: {products[0]?.Name}, Price: { products[0]?.Price }"
            //});

            //return View(new string[] { products[0]?.Name ?? "No Value" });

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
 