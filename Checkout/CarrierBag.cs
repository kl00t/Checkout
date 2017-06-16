﻿namespace Checkout.Core
{
	/// <summary>
	/// Carrier Bag class.
	/// </summary>
	public class CarrierBag : ICarrierBag
	{
		private readonly decimal BagPrice = 0.05m;

		private readonly int BagCapacity = 5;

		public CarrierBag()
		{
		}

		public decimal Charge { get; set; }

		public decimal CalculateBagCharge(int numberOfItems)
		{
			if (numberOfItems <= 0)
			{
				return Charge = 0;
			}

			var bagsRequired = (numberOfItems / BagCapacity) + 1;
		
			var bagCharge = bagsRequired * BagPrice;
			return Charge = bagCharge;
		}
	}
}