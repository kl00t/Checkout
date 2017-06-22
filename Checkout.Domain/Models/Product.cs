namespace Checkout.Domain.Models
{
    using System;
    using Interfaces;

    /// <summary>
    /// Products that are scanned at the checkout.
    /// </summary>
    /// <seealso cref="Checkout.Domain.Interfaces.IProduct" />
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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the special offer identifier.
        /// </summary>
        /// <value>
        /// The special offer identifier.
        /// </value>
        public Guid SpecialOfferId { get; set; }

        /// <summary>
        /// Gets or sets the special offer.
        /// </summary>
        /// <value>
        /// The special offer.
        /// </value>
        public virtual SpecialOffer SpecialOffer { get; set; }
    }
}