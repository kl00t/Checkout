namespace Checkout.Data
{
    public class Product : IProduct
    {
		public Product()
		{
			SpecialOffer = new SpecialOffer();
		}

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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

		public SpecialOffer SpecialOffer { get; set; }
    }
}