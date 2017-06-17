using Checkout.Data;
using Checkout.Core;
using TechTalk.SpecFlow;
using Moq;
using NUnit.Framework;
using System;

namespace Checkout.BDD.Tests
{
    [Binding]
    public class CheckoutSteps
    {
		/// <summary>
		/// The checkout.
		/// </summary>
		private static Core.Checkout _checkout;

		private static Mock<IProductRepository> _mockProductRepository;

		private static Mock<ICarrierBag> _mockCarrierBag;

		[BeforeScenario]
		public void BeforeScenario()
		{
			_mockProductRepository = new Mock<IProductRepository>();
			_mockCarrierBag = new Mock<ICarrierBag>();
			_mockCarrierBag.Setup(x => x.CalculateBagCharge(It.IsAny<int>())).Returns(0);

			_mockProductRepository.Setup(x => x.GetProductBySkuCode("A"))
				.Returns(new Product
				{
					Sku = "A",
					UnitPrice = 9.99m,
					Description = "Pineapple",
					SpecialOffer = new SpecialOffer
					{
						IsAvailable = true,
						Quantity = 3,
						Discount = 20
					}
				});
		}

		[AfterFeature]
		public static void AfterFeature()
		{
			// run after the test have run
		}

		[Given(@"I have a checkout system")]
        public static void GivenIHaveACheckoutSystem()
        {
			_checkout = new Core.Checkout(_mockProductRepository.Object, _mockCarrierBag.Object);
        }

		[Given(@"I scan an (.*) using the checkout")]
		public void GivenIScanAnUsingTheCheckout(string item)
		{
			_checkout.Scan(item);
		}

		[When(@"I calculate the total price")]
        public void WhenICalculateTheTotalPrice()
        {
			var totalPrice = _checkout.GetTotalPrice();
			ScenarioContext.Current.Add("TotalPrice", totalPrice);
		}

		[Then(@"the (.*) should be correct")]
		public void ThenTheShouldBeCorrect(string totalprice)
		{
			Assert.AreEqual(Convert.ToDecimal(totalprice), _checkout.TotalPrice);
		}
	}
}
