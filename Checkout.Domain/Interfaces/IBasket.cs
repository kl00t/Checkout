namespace Checkout.Domain.Interfaces
{
    using System;

    /// <summary>
    /// Basket interface.
    /// </summary>
    public interface IBasket
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        Guid ProductId { get; set; }
    }
}