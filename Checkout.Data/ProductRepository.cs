namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Product Repository class.
    /// </summary>
    /// <seealso cref="Checkout.Data.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The list of products.
        /// </summary>
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        public ProductRepository()
        {
			_products = new List<Product>();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(string sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Save()
        {
            throw new NotImplementedException();
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