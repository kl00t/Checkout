namespace Checkout.Domain.Interfaces
{

    using System;

    /// <summary>
    /// Special Offer interface definition.
    /// </summary>
    public interface ISpecialOffer
	{
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the special offer is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if the special offer is available; otherwise, <c>false</c>.
        /// </value>
        bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the quantity needed for the special offer to be applied.
        /// </summary>
        /// <value>
        /// The quantity needed for the special offer to be applied.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the total items.
        /// </summary>
        /// <value>
        /// The discount applied to the total items.
        /// </value>
        decimal Discount { get; set; }
	}
}