namespace Checkout.Domain.Models
{
    using System.Collections.Generic;
    using Domain.Interfaces;

    /// <summary>
    /// Basket class.
    /// </summary>
    /// <seealso cref="IBasket" />
    public class Basket : IBasket
    {
        /// <summary>
        /// Adds the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Remove(Product product)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public List<Product> Products { get; set; }
    }
}