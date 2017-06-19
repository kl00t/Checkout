namespace Checkout.Data
{
    using System.Collections.Generic;

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
        /// Inserts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Insert(Product product)
        {
            _products.Add(product);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(string sku)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Save()
        {
            throw new System.NotImplementedException();
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