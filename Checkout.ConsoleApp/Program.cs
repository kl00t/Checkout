namespace Checkout.ConsoleApp
{
    using System;
    using System.Linq;
    using Data;
    using Domain.Models;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CheckoutContext())
            {
                context.Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Sku = "A",
                    UnitPrice = 9.99m,
                    Description = "new product",
                    SpecialOffer = new SpecialOffer
                    {
                        Id = Guid.NewGuid(),
                        IsAvailable = false
                    }
                });

                context.SaveChanges();

                var products = context.Products.ToList<Product>();
                foreach (var product in products)
                {
                    Console.WriteLine(product.Sku);
                }

                Console.WriteLine(@"Press any key.");
                Console.ReadLine();
            }
        }
    }
}