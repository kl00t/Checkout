namespace Checkout.Data.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Product Repository Tests.
    /// </summary>
    [TestFixture]
    public class ProductRepositoryTests
    {
        /// <summary>
        /// The product repository.
        /// </summary>
        private ProductRepository _productRepository;

        [SetUp]
        public void SetUp()
        {
            _productRepository = new ProductRepository();
        }

        [Test]
        public void EnsureThatProductAddedIsRetrievedCorrectly()
        {
            _productRepository.Insert(
                new Product
                {
                    Sku = "A",
                    UnitPrice = 7.79m,
                    Description = "Orange",
					SpecialOffer = new SpecialOffer
					{
						IsAvailable = false
					}
                });

            var product = _productRepository.GetProductBySkuCode("A");

            Assert.AreEqual("A", product.Sku);
            Assert.AreEqual(7.79m, product.UnitPrice);
            Assert.AreEqual("Orange", product.Description);
        }

        [Test]
        public void EnsureThatProductSkuCodeReturnsCorrectPrice()
        {
            _productRepository.Insert(
            new Product
            {
                Sku = "Y",
                UnitPrice = 8m,
                Description = "Pineapple",
				SpecialOffer = new SpecialOffer
				{
					IsAvailable = false
				}
			});

            Assert.AreEqual(8m, _productRepository.GetProductUnitPrice("Y"));
        }
    }
}