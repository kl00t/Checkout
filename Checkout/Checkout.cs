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

            // TODO: We notice a lot of duplication here so the next round of refactoring I will remove this.
            if (item == "A")
            {
                TotalPrice = TotalPrice + 50;
            }

            if (item == "B")
            {
                TotalPrice = TotalPrice + 30;
            }

            if (item == "C")
            {
                TotalPrice = TotalPrice + 20;
            }

            if (item == "D")
            {
                TotalPrice = TotalPrice + 15;
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