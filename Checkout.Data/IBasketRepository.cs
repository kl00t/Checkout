namespace Checkout.Data
{
    using System;
    using Domain.Models;

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
    }
}