using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster
{
    public class ProductService
    {
        // Func delegate for flexible searching
        public List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();

            foreach (var p in products)
            {
                if (filter(p))
                    result.Add(p);
            }

            return result;
        }

        // Predicate delegate for filtering
        public List<Product> FilterProducts(List<Product> products, Predicate<Product> predicate)
        {
            List<Product> result = new();

            foreach (var p in products)
            {
                if (predicate(p))
                    result.Add(p);
            }

            return result;
        }
    }
}
