namespace _02.PriceCatalog
{
    using System;
    using System.Linq;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    public class CatalogDemo
    {
        const int TotalProducts = 500000;
        const decimal MinProductPrice = 10;
        const decimal MaxProductPrice = 500;
        const int SearchCount = 10000;
        const int ResultCount = 20;
        const decimal MinProductRange = 25;
        const decimal MaxProductRange = 125;
        static Random randomGenerator = new Random();

        struct Product 
        {
            public Product(decimal price, string name)
                :this()
            {
                this.Price = price;
                this.Name = name;
            }

            public decimal Price { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("Name: {0} Price: {1}", this.Name, this.Price);
            }
        }

        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            OrderedBag<Product> catalog = new OrderedBag<Product>(new Comparison<Product>((x, y) => x.Price.CompareTo(y.Price)));
            
            for (int i = 0; i < TotalProducts; i++)
            {
                decimal productPrice = randomGenerator.Next((int)MinProductPrice, (int)MaxProductPrice);
                string productName = "Product " + i;
                Product currentProduct = new Product(productPrice, productName);
                catalog.Add(currentProduct);
            }

            OrderedBag<Product>.View productsInRange = default(OrderedBag<Product>.View);

            for (int i = 0; i < SearchCount; i++)
            {
                productsInRange = catalog.Range(
                    new Product(MinProductRange + i * 0.001m, string.Empty), true, 
                    new Product(MaxProductRange + i * 0.001m, string.Empty), true);
            }

            var firstNResults = productsInRange.Take(ResultCount);
            Console.WriteLine(string.Join(Environment.NewLine, firstNResults));

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
