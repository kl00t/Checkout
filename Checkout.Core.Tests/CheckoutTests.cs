namespace Checkout.Core.Tests
{
    using Data;
    using NUnit.Framework;

    /// <summary>
    /// Test fixture for checkout.
    /// </summary>
    [TestFixture]
    public class CheckoutTests
    {
        /// <summary>
        /// The checkout.
        /// </summary>
        private Checkout _checkout;

        /// <summary>
        /// Called before each test is run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout(new ProductRepository(), new Basket());
        }

        [Test]
        public void VerifyThatNoScannedItemsReturnsZeroPrice()
        {
            _checkout.Scan(string.Empty);
            Assert.AreEqual(0, _checkout.GetTotalPrice());
        }

        [Test]
        public void VerifyScannedItemReturnsCorrectPrice()
        {
            _checkout.Scan("A");
            Assert.AreEqual(50, _checkout.GetTotalPrice());
        }

        [Test]
        public void VerifyTwoScannedItemsCalculatesTotalPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            Assert.AreEqual(80, _checkout.GetTotalPrice());
        }

        [Test]
        public void VerifyNoScannedItemIsIgnore()
        {
            _checkout.Scan("A");
            _checkout.Scan(string.Empty);
            _checkout.Scan("B");
            Assert.AreEqual(80, _checkout.GetTotalPrice());
        }

        [Test]
        public void VerifyAllScannedProductsReturnsCorrectTotalPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");
            Assert.AreEqual(115, _checkout.GetTotalPrice());
        }

        [Test]
        [Ignore]
        public void VerifyThatDiscountIsAppliedToScannedItems()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(130, _checkout.GetTotalPrice());
        }

        [Test]
        [Ignore]
        public void VerifyThatDiscountIsAppliedThenAdditionalItem()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(180, _checkout.GetTotalPrice());
        }

        [Test]
        [Ignore]
        public void VerifyThatMultipleDiscountsAppliedToScannedItemsInAnyOrder()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("A");
            Assert.AreEqual(175, _checkout.GetTotalPrice());
        }

        [Test]
        [ExpectedException(typeof(InvalidProductException))]
        public void VerifyThatAnInvalidScannedItemReturnsAnError()
        {
            _checkout.Scan("Z");
        }
    }
}