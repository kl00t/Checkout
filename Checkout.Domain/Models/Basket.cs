namespace Checkout.Domain.Models
{
    using System;
    using Domain.Interfaces;

    /// <summary>
    /// Basket class.
    /// </summary>
    /// <seealso cref="IBasket" />
    public class Basket : IBasket
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }
    }
}