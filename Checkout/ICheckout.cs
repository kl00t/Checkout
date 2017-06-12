namespace Checkout.Core
{
    /// <summary>
    /// Checkout interface.
    /// </summary>
    interface ICheckout
    {
        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The name of scanned item.</param>
        void Scan(string item);

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <returns>Returns the total price as a whole number.</returns>
        int GetTotalPrice();

        /// <summary>
        /// Gets the total discounts.
        /// </summary>
        /// <returns>Returns the total discounts message.</returns>
        string GetTotalDiscounts();
    }
}