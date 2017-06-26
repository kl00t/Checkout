namespace Checkout.Domain.Models
{
    using System;
    using Interfaces;

    /// <summary>
    /// Product special offer class.
    /// </summary>
    /// <seealso cref="Checkout.Domain.Interfaces.ISpecialOffer" />
    public class SpecialOffer : ISpecialOffer
	{
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }
	}
}