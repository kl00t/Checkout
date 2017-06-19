namespace Checkout.Core
{
	/// <summary>
	/// Carrier Bag interface.
	/// </summary>
	public interface ICarrierBag
	{
        /// <summary>
        /// Gets or sets the carrier bag charge.
        /// </summary>
        /// <value>
        /// The carrier bag charge.
        /// </value>
        decimal Charge { get; set; }

		/// <summary>
		/// Calculate how much the charge is for bags based on the number of items.
		/// </summary>
		/// <param name="numberOfItems"></param>
		/// <returns>Returns the calculation for the number of bags.</returns>
		decimal CalculateBagCharge(int numberOfItems);
	}
}