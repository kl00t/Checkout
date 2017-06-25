namespace Checkout.Data
{
    using System;
    using Domain.Models;
	using System.Collections.Generic;

	public interface IBasketRepository : IRepository<Basket, Guid>
    {
        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Add(Product product);

        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Remove(Product product);

		/// <summary>
		/// Gets all the basket products.
		/// </summary>
		/// <param name="basketId"></param>
		/// <returns>Returns all products.</returns>
		List<Product> GetBasketProducts(Guid basketId);
    }
}