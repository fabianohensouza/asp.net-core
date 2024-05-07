//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product?[] products = Product.GetProducts();

            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            return View("Index", new string[] { $"Total: {cartTotal:C2}" });

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
