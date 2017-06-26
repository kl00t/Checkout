namespace Checkout.Data
{
	using System;
	using System.Collections.Generic;
	using Domain.Models;

    /// <summary>
    /// Mock basket repository.
    /// </summary>
    /// <seealso cref="Checkout.Data.IBasketRepository" />
    public class MockBasketRepository : IBasketRepository
	{
        /// <summary>
        /// The baskets
        /// </summary>
        private readonly Dictionary<Guid, List<Product>> _baskets;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockBasketRepository"/> class.
        /// </summary>
        public MockBasketRepository()
        {
            _baskets = FakeData.FakeBaskets();
		}

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns the entity by the id.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Basket GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Insert(Basket entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(Basket entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Delete(Basket entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddProductItem(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveProductItem(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the basket products.
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns>
        /// Returns all products.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Product> GetBasketProducts(Guid basketId)
		{
			throw new NotImplementedException();
		}
	}
}