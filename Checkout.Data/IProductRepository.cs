namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;

    /// <summary>
    /// Product repository interface definition.
    /// </summary>
    public interface IProductRepository : IRepository<Product, Guid>
    {
        /// <summary>
        /// Gets the product by sku code.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>Returns the product by the sku code.</returns>
        Product GetProductBySkuCode(string skuCode);

        /// <summary>
        /// Gets the product unit price.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>Returns the product unit price by the sku code.</returns>
        decimal GetProductUnitPrice(string skuCode);

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        List<Product> GetAllProducts();

		AddProductResponse AddProduct(Product product);
	}
}