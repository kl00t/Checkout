using System;

namespace Checkout.Core
{
	/// <summary>
	/// Carrier Bag class.
	/// </summary>
	public class CarrierBag : ICarrierBag
	{
	    /// <summary>
	    /// The bag price.
	    /// </summary>
	    private readonly decimal _bagPrice;

	    /// <summary>
	    /// The bag capacity.
	    /// </summary>
	    private readonly int _bagCapacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierBag"/> class.
        /// </summary>
        public CarrierBag()
	    {
	        _bagPrice = _bagPrice = CheckoutSettings.Default.CarrierBagPrice;
            _bagCapacity = CheckoutSettings.Default.CarrierBagCapacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierBag"/> class.
        /// </summary>
        /// <param name="bagPrice">The bag price.</param>
        /// <param name="bagCapacity">The bag capacity.</param>
        public CarrierBag(decimal bagPrice, int bagCapacity)
	    {
	        _bagPrice = bagPrice;
	        _bagCapacity = bagCapacity;
	    }

        /// <summary>
        /// Gets or sets the carrier bag charge.
        /// </summary>
        /// <value>
        /// The carrier bag charge.
        /// </value>
        public decimal Charge { get; set; }

        /// <summary>
        /// Gets or sets the bags required.
        /// </summary>
        /// <value>
        /// The bags required.
        /// </value>
        public int BagsRequired { get; set; }

        /// <summary>
        /// Calculate how much the charge is for bags based on the number of items.
        /// </summary>
        /// <param name="numberOfItems">The number of items scanned.</param>
        /// <returns>
        /// Returns the calculation for the number of bags.
        /// </returns>
        public decimal CalculateBagCharge(int numberOfItems)
		{
			if (numberOfItems <= 0)
			{
				return Charge = 0;
			}

		    int remainder;
			var bagsRequired = Math.DivRem(numberOfItems, _bagCapacity, out remainder);
			if (remainder > 0)
			{
				// bag overflow, so add another bag
				bagsRequired += 1;
			}

            BagsRequired = bagsRequired;
			return Charge = BagsRequired * _bagPrice;
		}
	}
}