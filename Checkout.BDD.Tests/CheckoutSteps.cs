namespace Checkout.BDD.Tests
{
    using Checkout.Data;
    using Checkout.Core;
    using TechTalk.SpecFlow;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Domain.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Checkout BDD steps file.
    /// </summary>
    [Binding]
    public class CheckoutSteps
    {
        /// <summary>
        /// The checkout.
        /// </summary>
        private static Checkout _checkout;

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
        /// Givens the i have a system containing products.
        /// </summary>
        /// <param name="table">The table.</param>
        [Given(@"I have a system containing products")]
        public void GivenIHaveASystemContainingProducts(Table table)
        {
            var products = table.Rows.Select(row => new Product
            {
                Sku = row["sku"],
                UnitPrice = Convert.ToDecimal(row["unitprice"]),
                Description = row["description"],
                SpecialOffer = new SpecialOffer
                {
                    IsAvailable = Convert.ToBoolean(row["specialoffer"]),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    Discount = Convert.ToDecimal(row["discount"])
                }
            }).ToList();

            foreach (var product in products)
            {
                _mockProductRepository.Setup(x => x.GetProductBySkuCode(product.Sku)).Returns(product);
            }
        }

        /// <summary>
        /// Givens the charge for carrier bags is.
        /// </summary>
        /// <param name="carrierBagCharge">The carrier bag charge.</param>
        [Given(@"the charge for carrier bags is (.*)")]
        public void GivenTheChargeForCarrierBagsIs(decimal carrierBagCharge)
        {
            _mockCarrierBag.Setup(x => x.CalculateBagCharge(It.IsAny<int>())).Returns(carrierBagCharge);
        }

        /// <summary>
        /// Givens the i have a checkout system.
        /// </summary>
        [Given(@"I have a checkout system")]
        public static void GivenIHaveACheckoutSystem()
        {
            _checkout = new Checkout(_mockProductRepository.Object, _mockCarrierBag.Object);
        }

        /// <summary>
        /// Whens the i calculate the total price.
        /// </summary>
        [When(@"I calculate the total price")]
        public void WhenICalculateTheTotalPrice()
        {
            ScenarioContext.Current.Add("TotalPrice", _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Thens the subtotal should be.
        /// </summary>
        /// <param name="subTotal">The sub total.</param>
        [Then(@"the subtotal should be (.*)")]
        public void ThenTheSubtotalShouldBe(decimal subTotal)
        {
            Assert.AreEqual(subTotal, _checkout.SubTotal);
        }

        /// <summary>
        /// Thens the price should be.
        /// </summary>
        /// <param name="totalPrice">The total price.</param>
        [Then(@"the price should be (.*)")]
        public void ThenThePriceShouldBe(decimal totalPrice)
        {
            Assert.AreEqual(totalPrice, Convert.ToDecimal(ScenarioContext.Current["TotalPrice"]));
        }

        /// <summary>
        /// Givens the i scan using the checkout.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="item">The item.</param>
        [Given(@"I scan (.*) (.*) using the checkout")]
        public void GivenIScanUsingTheCheckout(int quantity, string item)
        {
            for (var i = 0; i < quantity; i++)
            {
                _checkout.Scan(item);
            }
        }

        /// <summary>
        /// Thens the total discount applied is.
        /// </summary>
        /// <param name="totalDiscount">The total discount.</param>
        [Then(@"the total discount applied is (.*)")]
        public void ThenTheTotalDiscountAppliedIs(decimal totalDiscount)
        {
            Assert.AreEqual(totalDiscount, _checkout.TotalDiscount);
        }
    }
}