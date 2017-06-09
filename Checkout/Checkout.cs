namespace Checkout.Core
{
    /// <summary>
    /// Checkout core class.
    /// </summary>
    public class Checkout : ICheckout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        public Checkout()
        {
        }

        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The name of scanned item.</param>
        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                TotalPrice += 0;
            }

            TotalPrice += GetProductUnitPrice(item);
        }

        private static int GetProductUnitPrice(string skuCode)
        {
            switch (skuCode)
            {
                case "A":
                    return 50;
                case "B":
                    return 30;
                case "C":
                    return 20;
                case "D":
                    return 15;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gets the total price.
        /// </summary>
        /// <returns>
        /// Returns the total price as a whole number.
        /// </returns>
        public int GetTotalPrice()
        {
            return TotalPrice;
        }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public int TotalPrice { get; set; }
    }
}