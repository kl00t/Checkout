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
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the entity by the id.
        /// </returns>
        public Product GetById(Guid id)
        {
            using (var context = new CheckoutContext())
            {
                return context.Products.FirstOrDefault(x => x.Id.Equals(id));
            }
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Insert(Product product)
        {
            using (var context = new CheckoutContext())
            {
                context.Products.Add(product);
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(Product product)
        {
            //var entity = GetProductBySkuCode(product.Sku);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Delete(Product product)
        {
            var entity = GetProductBySkuCode(product.Sku);
            using (var context = new CheckoutContext())
            {
                context.Products.Remove(entity);
            }
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
            using (var context = new CheckoutContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Sku == skuCode);
                if (product == null)
                {
                    throw new InvalidProductException();
                }

                return product;
            }
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

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        public List<Product> GetAllProducts()
        {
            using (var context = new CheckoutContext())
            {
                return context.Products.ToList();
            }
        }

		public AddProductResponse AddProduct(Product product)
		{
			Insert(product);

			return new AddProductResponse
			{
				ProductId = Guid.NewGuid()
			};
		}
	}
}