namespace Checkout.Data
{
    /// <summary>
    /// Products that are scanned at the checkout.
    /// </summary>
    /// <seealso cref="Checkout.Data.IProduct" />
    public class Product : IProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
		{
			SpecialOffer = new SpecialOffer();
		}

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
        public string Sku { get; set; }

		/// <summary>
		/// Gets or sets the unit price.
		/// </summary>
		/// <value>
		/// The unit price.
		/// </value>
		public int UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the special offer.
        /// </summary>
        /// <value>
        /// The special offer.
        /// </value>
        public SpecialOffer SpecialOffer { get; set; }
    }
}