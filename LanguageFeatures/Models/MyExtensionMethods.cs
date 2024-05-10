namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product?> products)
        {
            decimal total = 0;
            foreach (Product? prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }

        public static IEnumerable<Product?> FilterByPrice(
            this IEnumerable<Product?> productEnum, 
            decimal minimumPrice)
        {
            foreach (Product? prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }

        //public static decimal TotalPrices(this ShoppingCart cartParam)
        //{
        //    decimal total = 0;
        //    if (cartParam.Products != null)
        //    {
        //        foreach (Product? prod in cartParam.Products)
        //        {
        //            total += prod?.Price ?? 0;
        //        }
        //    }
        //    return total;
        //}
    }
}