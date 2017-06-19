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
        private readonly decimal _bagPrice = CheckoutSettings.Default.CarrierBagPrice;

        /// <summary>
        /// The bag capacity.
        /// </summary>
        private readonly int _bagCapacity = CheckoutSettings.Default.CarrierBagCapacity;

        /// <summary>
        /// Gets or sets the carrier bag charge.
        /// </summary>
        /// <value>
        /// The carrier bag charge.
        /// </value>
        public decimal Charge { get; set; }

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
				// bag overlflow, so add another bag
				bagsRequired += 1;
			}

			var bagCharge = bagsRequired * _bagPrice;
			return Charge = bagCharge;
		}
	}
}