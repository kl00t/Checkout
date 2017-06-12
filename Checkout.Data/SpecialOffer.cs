namespace Checkout.Data
{
    /// <summary>
    /// Product special offer class.
    /// </summary>
    /// <seealso cref="Checkout.Data.ISpecialOffer" />
    public class SpecialOffer : ISpecialOffer
	{
        /// <summary>
        /// Gets or sets a value indicating whether the special offer is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if the special offer is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the quantity needed for the special offer to be applied.
        /// </summary>
        /// <value>
        /// The quantity needed for the special offer to be applied.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the total items.
        /// </summary>
        /// <value>
        /// The discount applied to the total items.
        /// </value>
        public int Discount { get; set; }
	}
}