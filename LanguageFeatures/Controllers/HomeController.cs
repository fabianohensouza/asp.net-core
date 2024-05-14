//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //bool FilterByPrice(Product? p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}

        public ViewResult Index()
        {
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            //Func<Product?, bool> nameFilter = delegate (Product? prod) {
            //    return prod?.Name?[0] == 'S';
            //};

            decimal priceFilterTotal = productArray
                .Filter(p => (p?.Price ?? 0) >= 20)
                .TotalPrices();
            decimal nameFilterTotal = productArray
                .Filter(p => p?.Name?[0] == 'S')
                .TotalPrices();

            return View("Index", new string[] {
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}" });

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

        public ViewResult Index2()
        {
            return View(Product.GetProducts().Select(p => p?.Name));
        }

        public ViewResult Index3() => View(Product.GetProducts().Select(p => p?.Name));

        public ViewResult Index4()
        {
            return View(Product.GetProducts()
                .Where(pr => (pr?.NameBeginsWithS == true))
                .Select(p => p?.Name));
        }

        public ViewResult Index5()
        {
            var products = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };

            //return View(products.Select(p => p.GetType().Name)); 
            return View(products.Select(p => p.Name));
        }

        public ViewResult Index6()
        {
            IProductSelection cart = new ShoppingCart2(
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            );

            return View(cart.Names);
            //return View(cart.Products?.Select(p => p.Name));
        }
    }
}
 