using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster
{

    public class ReportService
    {
        // Action delegate for printing
        public void PrintReport(List<Product> products, Action<Product> printer)
        {
            foreach (var p in products)
                printer(p);
        }

        // Func delegate for transformation
        public List<T> TransformProducts<T>(List<Product> products, Func<Product, T> transformer)
        {
            List<T> result = new();

            foreach (var p in products)
                result.Add(transformer(p));

            return result;
        }
    }
}
