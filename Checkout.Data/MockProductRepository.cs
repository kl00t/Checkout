namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Mock Product repository.
    /// </summary>
    /// <seealso cref="Checkout.Data.IProductRepository" />
    public class MockProductRepository : IProductRepository
    {
        /// <summary>
        /// The list of products.
        /// </summary>
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public MockProductRepository()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Sku = "A",
                    UnitPrice = 50m,
                    Description = "Pineapple",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 3,
                        Discount = 20
                    }
                },
                new Product
                {
                    Sku = "B",
                    UnitPrice = 30m,
                    Description = "Mango",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 2,
                        Discount = 15
                    }
                },
                new Product
                {
                    Sku = "C",
                    UnitPrice = 20m,
                    Description = "Kiwi",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = false
                    }
                },
                new Product
                {
                    Sku = "D",
                    UnitPrice = 15m,
                    Description = "Melon",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = false
                    }
                },
                new Product
                {
                    Sku = "E",
                    UnitPrice = 9.99m,
                    Description = "Banana",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 3,
                        Discount = 9.99m
                    }
                }
            };
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the entity by the id.
        /// </returns>
        public Product GetById(string id)
        {
            return _products.FirstOrDefault(x => x.Sku.Equals(id));
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(Product entity)
        {
            _products.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(Product entity)
        {
            _products.Remove(entity);
        }

        /// <summary>
        /// Gets the product by sku code.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>
        /// Returns the product by the sku code.
        /// </returns>
        /// <exception cref="InvalidProductException"></exception>
        public Product GetProductBySkuCode(string skuCode)
        {
            var product = _products.Find(x => x.Sku == skuCode);
            if (product == null)
            {
                throw new InvalidProductException();
            }

            return product;
        }

        /// <summary>
        /// Gets the product unit price.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>
        /// Returns the product unit price by the sku code.
        /// </returns>
        public decimal GetProductUnitPrice(string skuCode)
        {
            return GetProductBySkuCode(skuCode).UnitPrice;
        }
    }
}