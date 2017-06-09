namespace Checkout.Core.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Test fixture for checkout.
    /// </summary>
    [TestFixture]
    public class CheckoutTests
    {
        /// <summary>
        /// Called before each test is run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void VerifyThatNoScannedItemsReturnsZeroPrice()
        {
            var checkout = new Checkout();
            checkout.Scan(string.Empty);
            Assert.AreEqual(0, checkout.GetTotalPrice());
        }
    }
}