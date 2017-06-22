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
                UnitPrice = 9.99m,
                Description = "new product",
                SpecialOffer = new SpecialOffer
                {
                    Id = Guid.NewGuid(),
                    IsAvailable = false
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