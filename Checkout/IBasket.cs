namespace Checkout.Core
{
    using System.Collections.Generic;
    using Data;
    using Domain.Models;

    /// <summary>
    /// Basket interface.
    /// </summary>
    public interface IBasket
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
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        List<Product> Products { get; set; }
    }
}