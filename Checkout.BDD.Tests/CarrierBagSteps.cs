namespace Checkout.BDD.Tests
{

    using System;
    using Core;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Carrier Bag Test Steps.
    /// </summary>
    [Binding]
    public class CarrierBagSteps
    {
        /// <summary>
        /// The checkout.
        /// </summary>
        private static CarrierBag _carrierBag;

        /// <summary>
        /// Test runs befores the scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            _carrierBag = new CarrierBag();
        }

        /// <summary>
        /// Givens the i have a carrier bag.
        /// </summary>
        [Given(@"I have a carrier bag")]
        public void GivenIHaveACarrierBag()
        {
            var bagCharge = Convert.ToDecimal(ScenarioContext.Current["bagCharge"]);
            var bagCapacity = Convert.ToInt32(ScenarioContext.Current["bagCapacity"]);
            _carrierBag = new CarrierBag(bagCharge, bagCapacity);
        }

        /// <summary>
        /// Givens the cost for each carrier bag is.
        /// </summary>
        /// <param name="bagCharge">The bag charge.</param>
        [Given(@"the cost for each carrier bag is (.*)")]
        public void GivenTheCostForEachCarrierBagIs(decimal bagCharge)
        {
            ScenarioContext.Current.Add("bagCharge", bagCharge);
        }

        /// <summary>
        /// Givens the bag capacity holds items.
        /// </summary>
        /// <param name="bagCapacity">The bag capacity.</param>
        [Given(@"the bag capacity holds (.*) items")]
        public void GivenTheBagCapacityHoldsItems(int bagCapacity)
        {
            ScenarioContext.Current.Add("bagCapacity", bagCapacity);
        }

        /// <summary>
        /// Givens the i have in my shopping basket.
        /// </summary>
        /// <param name="numberOfitems">The number ofitems.</param>
        [Given(@"I have (.*) in my shopping basket")]
        public void GivenIHaveInMyShoppingBasket(int numberOfitems)
        {
            _carrierBag.CalculateBagCharge(numberOfitems);
        }

        /// <summary>
        /// Thens the total nunber of bags required is.
        /// </summary>
        /// <param name="numberOfBagsRequired">The number of bags required.</param>
        [Then(@"the total number of bags required is (.*)")]
        public void ThenTheTotalNunberOfBagsRequiredIs(int numberOfBagsRequired)
        {
            Assert.AreEqual(numberOfBagsRequired, _carrierBag.BagsRequired);
        }

        /// <summary>
        /// Thens the total charge for bags in.
        /// </summary>
        /// <param name="bagCharge">The bag charge.</param>
        [Then(@"the total charge for bags in (.*)")]
        public void ThenTheTotalChargeForBagsIn(decimal bagCharge)
        {
            Assert.AreEqual(bagCharge, _carrierBag.Charge);
        }
    }
}