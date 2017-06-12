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
                    UnitPrice = 77,
                    Description = "Orange",
					SpecialOffer = new SpecialOffer
					{
						IsAvailable = false
					}
                });

            var product = _productRepository.GetProductBySkuCode("A");

            Assert.AreEqual("A", product.Sku);
            Assert.AreEqual(77, product.UnitPrice);
            Assert.AreEqual("Orange", product.Description);
        }

        [Test]
        public void EnsureThatProductSkuCodeReturnsCorrectPrice()
        {
            _productRepository.Insert(
            new Product
            {
                Sku = "Y",
                UnitPrice = 88,
                Description = "Pineapple",
				SpecialOffer = new SpecialOffer
				{
					IsAvailable = false
				}
			});

            Assert.AreEqual(88, _productRepository.GetProductUnitPrice("Y"));
        }
    }
}