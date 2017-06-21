namespace Checkout.Data.Tests
{

    using Domain.Exceptions;
    using Domain.Models;
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

        /// <summary>
        /// Sets up the test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _productRepository = new ProductRepository();
        }

        /// <summary>
        /// Ensures the that product added is retrieved correctly.
        /// </summary>
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

        /// <summary>
        /// Ensures the that product is removed correctly.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidProductException))]
        public void EnsureThatProductIsRemovedCorrectly()
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

            _productRepository.Delete(_productRepository.GetProductBySkuCode("A"));
            _productRepository.GetProductBySkuCode("A");
        }

        /// <summary>
        /// Ensures the that product sku code returns correct price.
        /// </summary>
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