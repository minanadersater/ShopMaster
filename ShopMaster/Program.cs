namespace ShopMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

            ProductService productService = new();
            ReportService reportService = new();

            #region Task 01 : Smart Search

            //Console.WriteLine("--- Electronics ---");
            //Print(productService.SearchProducts(catalog, p => p.Category == "Electronics"));

            //Console.WriteLine("\n--- Under $50 ---");
            //Print(productService.SearchProducts(catalog, p => p.Price < 50));

            //Console.WriteLine("\n--- In Stock ---");
            //Print(productService.SearchProducts(catalog, p => p.Stock > 0));

            //Console.WriteLine("\n--- Clothing Under $100 ---");
            //Print(productService.SearchProducts(catalog,
            //    p => p.Category == "Clothing" && p.Price < 100));
            #endregion

            #region Task 03.1 : Reports

            //Console.WriteLine("\n--- Short Report ---");
            //reportService.PrintReport(catalog,
            //    p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            //Console.WriteLine("\n--- Detailed Report ---");
            //reportService.PrintReport(catalog,
            //    p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            #endregion


            #region Task 03.2 : Transform

            Console.WriteLine("\n--- Summary List ---");
            var summary = reportService.TransformProducts(catalog,
                p => $"{p.Name} (${p.Price})");
            summary.ForEach(Console.WriteLine);

            Console.WriteLine("\n--- Price Labels ---");
            var labels = reportService.TransformProducts(catalog,
                p => p.Price > 100 ? "Expensive!" : "Affordable");

            for (int i = 0; i < catalog.Count; i++)
            {
                Console.WriteLine($"{catalog[i].Name}: {labels[i]}");
            }
            #endregion

            #region Task 03.3 : Low Stock

            Console.WriteLine("\n--- Low-Stock Alert ---");

            var lowStock = productService.FilterProducts(catalog, p => p.Stock < 20);

            foreach (var p in lowStock)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }
            #endregion
        }

        static void Print(List<Product> list)
        {
            foreach (var p in list)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
        }
    }
}