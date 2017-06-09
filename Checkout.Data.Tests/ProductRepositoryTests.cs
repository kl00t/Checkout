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
        public void EnsureThatProductSkuCodeReturnsCorrectPrice()
        {
            _productRepository.Insert(
            new Product
            {
                Id = 1,
                Sku = "Y",
                UnitPrice = 88
            });

            Assert.AreEqual(88, _productRepository.GetProductUnitPrice("Y"));
        }
    }
}