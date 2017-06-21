namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Exceptions;
    using Domain.Models;

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