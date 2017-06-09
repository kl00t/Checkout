namespace Checkout.Core.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Test fixture for checkout.
    /// </summary>
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout _checkout;

        /// <summary>
        /// Called before each test is run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout();
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
    }
}