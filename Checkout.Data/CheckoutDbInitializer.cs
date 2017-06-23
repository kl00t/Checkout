namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Domain.Models;

    public class CheckoutDbInitializer : CreateDatabaseIfNotExists<CheckoutContext>
    {
        protected override void Seed(CheckoutContext context)
        {
            IList<Product> products = new List<Product>();

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Sku = "A",
                UnitPrice = 50m,
                Description = "Pineapple",
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = true,
                    Quantity = 3,
                    Discount = 20
                }
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Sku = "B",
                UnitPrice = 30m,
                Description = "Mango",
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = true,
                    Quantity = 2,
                    Discount = 15
                }
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Sku = "C",
                UnitPrice = 20m,
                Description = "Kiwi",
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = false
                }
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Sku = "D",
                UnitPrice = 15m,
                Description = "Melon",
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = false
                }
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Sku = "E",
                UnitPrice = 9.99m,
                Description = "Banana",
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = true,
                    Quantity = 3,
                    Discount = 9.99m
                }
            });

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            base.Seed(context);
        }
    }
}