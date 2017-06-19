namespace Checkout.Core
{
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Basket class.
    /// </summary>
    /// <seealso cref="Checkout.Core.IBasket" />
    public class Basket : IBasket
    {
        public List<Product> Products { get; set; }
    }
}