namespace Checkout.Core
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Basket interface.
    /// </summary>
    public interface IBasket
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        List<Product> Products { get; set; }
    }
}