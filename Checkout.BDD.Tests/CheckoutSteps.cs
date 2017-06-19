namespace Checkout.BDD.Tests
{
    using Checkout.Data;
    using Checkout.Core;
    using TechTalk.SpecFlow;
    using Moq;
    using NUnit.Framework;
    using System;

    /// <summary>
    /// Checkout BDD steps file.
    /// </summary>
    [Binding]
    public class CheckoutSteps
    {
		/// <summary>
		/// The checkout.
		/// </summary>
		private static Core.Checkout _checkout;

        /// <summary>
        /// The mock product repository
        /// </summary>
        private static Mock<IProductRepository> _mockProductRepository;

        /// <summary>
        /// The mock carrier bag
        /// </summary>
        private static Mock<ICarrierBag> _mockCarrierBag;

        /// <summary>
        /// Test runs befores the scenario.
        /// </summary>
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

        /// <summary>
        /// Runs after the feature.
        /// </summary>
        [AfterFeature]
		public static void AfterFeature()
		{
			// run after the test have run
		}

        /// <summary>
        /// Givens the i have a checkout system.
        /// </summary>
        [Given(@"I have a checkout system")]
        public static void GivenIHaveACheckoutSystem()
        {
			_checkout = new Core.Checkout(_mockProductRepository.Object, _mockCarrierBag.Object);
        }

        /// <summary>
        /// Givens the i scan an using the checkout.
        /// </summary>
        /// <param name="item">The item.</param>
        [Given(@"I scan an (.*) using the checkout")]
		public void GivenIScanAnUsingTheCheckout(string item)
		{
			_checkout.Scan(item);
		}

        /// <summary>
        /// Whens the i calculate the total price.
        /// </summary>
        [When(@"I calculate the total price")]
        public void WhenICalculateTheTotalPrice()
        {
			var totalPrice = _checkout.GetTotalPrice();
			ScenarioContext.Current.Add("TotalPrice", totalPrice);
		}

        /// <summary>
        /// Thens the should be correct.
        /// </summary>
        /// <param name="totalprice">The totalprice.</param>
        [Then(@"the (.*) should be correct")]
		public void ThenTheShouldBeCorrect(string totalprice)
		{
			Assert.AreEqual(Convert.ToDecimal(totalprice), _checkout.TotalPrice);
		}
	}
}