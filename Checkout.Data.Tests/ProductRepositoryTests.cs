namespace Checkout.Data.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ProductRepositoryTests
    {
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
                    Id = 9,
                    Sku = "A",
                    UnitPrice = 77,
                    Description = "Orange",
					SpecialOffer = new SpecialOffer
					{
						IsAvailable = false
					}
                });

            var product = _productRepository.SelectById(9);

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
                Id = 1,
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