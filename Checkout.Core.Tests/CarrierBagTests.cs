namespace Checkout.Core.Tests
{
	using NUnit.Framework;
	using System;

	/// <summary>
	/// Test fixture for carrier bag.
	/// </summary>
	[TestFixture]
	public class CarrierBagTests
	{
		/// <summary>
		/// Carrier bag instance.
		/// </summary>
		private CarrierBag _carrierBag;

		/// <summary>
		/// Called before each test is run.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_carrierBag = new CarrierBag();
		}

		[Test]
		public void VerifyWhenNoItemsThenNoBagChargeIsApplied()
		{
			Assert.AreEqual(0.0m, _carrierBag.CalculateBagCharge(0));
		}

		[Test]
		public void VerifyThatWhenAtLeast1ItemThen1BagChargeIsApplied()
		{
			Assert.AreEqual(0.05m, _carrierBag.CalculateBagCharge(1));
		}

		[Test]
		public void VerifyThat5ItemsAppliesSingleCharge()
		{
			Assert.AreEqual(0.05m, _carrierBag.CalculateBagCharge(5));
		}

		[Test]
		public void VerifyThatOver5ItemsApplies2Charges()
		{
			Assert.AreEqual(0.10m, _carrierBag.CalculateBagCharge(6));
		}

		[Test]
		public void VerifyThat10ItemsApplies2BagCharges()
		{
			Assert.AreEqual(0.10m, _carrierBag.CalculateBagCharge(10));
		}

		[Test]
		[TestCase(0, "0.00")]
		[TestCase(1, "0.05")]
		[TestCase(2, "0.05")]
		[TestCase(3, "0.05")]
		[TestCase(4, "0.05")]
		[TestCase(6, "0.10")]
		[TestCase(7, "0.10")]
		[TestCase(8, "0.10")]
		[TestCase(9, "0.10")]
		[TestCase(10, "0.10")]
		[TestCase(11, "0.15")]
		public void VerifyCarrierBagChargeCalculation(int numberOfIitems, string expectedCharge)
		{
			var expectedResult = Convert.ToDecimal(expectedCharge);
			Assert.AreEqual(expectedResult, _carrierBag.CalculateBagCharge(numberOfIitems));
		}
	}
}