using System.Collections;

namespace LanguageFeatures.Models
{
    public class ShoppingCart2 : IProductSelection
    {
        private List<Product> products = new();

        public ShoppingCart2(params Product[] prods)
        {
            products.AddRange(prods);
        }

        public IEnumerable<Product>? Products
        {
            get => products;
        }

    }
}
