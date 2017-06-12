namespace Checkout.Core.Tests
{
    using Data;
	using Moq;
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
        /// The product repository.
        /// </summary>
        private Mock<IProductRepository> _mockProductRepository;

        /// <summary>
        /// Called before each test is run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _mockProductRepository = new Mock<IProductRepository>();

            _mockProductRepository.Setup(x => x.GetProductBySkuCode("A"))
                .Returns(new Product
                {
                    Sku = "A",
                    UnitPrice = 50m,
                    Description = "Pineapple",
                    SpecialOffer = new SpecialOffer
                    {
                        IsAvailable = true,
                        Quantity = 3,
                        Discount = 20
                    }
                });

            _mockProductRepository.Setup(x => x.GetProductBySkuCode("B"))
                .Returns(
                    new Product
                    {
                        Sku = "B",
                        UnitPrice = 30m,
                        Description = "Mango",
                        SpecialOffer = new SpecialOffer
                        {
                            IsAvailable = true,
                            Quantity = 2,
                            Discount = 15
                        }
                    });

            _mockProductRepository.Setup(x => x.GetProductBySkuCode("C"))
                .Returns(
                    new Product
                    {
                        Sku = "C",
                        UnitPrice = 20m,
                        Description = "Kiwi",
                        SpecialOffer = new SpecialOffer
                        {
                            IsAvailable = false
                        }
                    });

            _mockProductRepository.Setup(x => x.GetProductBySkuCode("D"))
                .Returns(
                    new Product
                    {
                        Sku = "D",
                        UnitPrice = 15m,
                        Description = "Melon",
                        SpecialOffer = new SpecialOffer
                        {
                            IsAvailable = false
                        }
                    });

            _mockProductRepository.Setup(x => x.GetProductBySkuCode("E"))
                .Returns(
                    new Product
                    {
                        Sku = "E",
                        UnitPrice = 9.99m,
                        Description = "Banana",
                        SpecialOffer = new SpecialOffer
                        {
                            IsAvailable = true,
                            Quantity = 3,
                            Discount = 9.99m
                        }
                    });

            _checkout = new Checkout(_mockProductRepository.Object);
        }

        /// <summary>
        /// Verifies the that no scanned items returns zero price.
        /// </summary>
        [Test]
        public void VerifyThatNoScannedItemsReturnsZeroPrice()
        {
            _checkout.Scan(string.Empty);
            Assert.AreEqual(0, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the scanned item returns correct price.
        /// </summary>
        [Test]
        public void VerifyScannedItemReturnsCorrectPrice()
        {
            _checkout.Scan("A");
            Assert.AreEqual(50, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the two scanned items calculates total price.
        /// </summary>
        [Test]
        public void VerifyTwoScannedItemsCalculatesTotalPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            Assert.AreEqual(80, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the no scanned item is ignore.
        /// </summary>
        [Test]
        public void VerifyNoScannedItemIsIgnore()
        {
            _checkout.Scan("A");
            _checkout.Scan(string.Empty);
            _checkout.Scan("B");
            Assert.AreEqual(80, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies all scanned products returns correct total price.
        /// </summary>
        [Test]
        public void VerifyAllScannedProductsReturnsCorrectTotalPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("C");
            _checkout.Scan("D");
            Assert.AreEqual(115, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that discount is applied to scanned items.
        /// </summary>
        [Test]
        public void VerifyThatDiscountIsAppliedToScannedItems()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(130, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that discount is applied then additional item.
        /// </summary>
        [Test]
        public void VerifyThatDiscountIsAppliedThenAdditionalItem()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(180, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that multiple discounts applied to scanned items in any order.
        /// </summary>
        [Test]
        public void VerifyThatMultipleDiscountsAppliedToScannedItemsInAnyOrder()
        {
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("A");
            Assert.AreEqual(175, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that an invalid scanned item returns an error.
        /// </summary>
        [Test]
        [ExpectedException(typeof (InvalidProductException))]
        public void VerifyThatAnInvalidScannedItemReturnsAnError()
        {
            _mockProductRepository.Setup(x => x.GetProductBySkuCode("Z")).Throws<InvalidProductException>();
            _checkout.Scan("Z");
        }

        /// <summary>
        /// Verifies the that discount is applied multiple times with same product.
        /// </summary>
        [Test]
        public void VerifyThatDiscountIsAppliedMultipleTimesWithSameProduct()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(260, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that discount is applied multiple times with multiple products.
        /// </summary>
        [Test]
        public void VerifyThatDiscountIsAppliedMultipleTimesWithMultipleProducts()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("B");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("B");
            _checkout.Scan("B");
            Assert.AreEqual(350, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that discounted items does not trigger discount.
        /// </summary>
        [Test]
        public void VerifyThatDiscountedItemsDoesNotTriggerDiscount()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            Assert.AreEqual(100, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that scanned item cancel has no effect on empty basket.
        /// </summary>
        [Test]
        public void VerifyThatScannedItemCancelHasNoEffectOnEmptyBasket()
        {
            _checkout.CancelScan("A");
            Assert.AreEqual(0, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the that an invalid scanned cancelled item returns an error.
        /// </summary>
        [Test]
        [ExpectedException(typeof (InvalidProductException))]
        public void VerifyThatAnInvalidScannedCancelledItemReturnsAnError()
        {
            _mockProductRepository.Setup(x => x.GetProductBySkuCode("Z")).Throws<InvalidProductException>();
            _checkout.CancelScan("Z");
        }

        /// <summary>
        /// Verifies the that scanned item can be cancelled.
        /// </summary>
        [Test]
        public void VerifyThatScannedItemCanBeCancelled()
        {
            _checkout.Scan("A");
            _checkout.CancelScan("A");
            Assert.AreEqual(0, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the no scan cancelled item is ignored.
        /// </summary>
        [Test]
        public void VerifyNoScanCancelledItemIsIgnored()
        {
            _checkout.CancelScan(string.Empty);
            Assert.AreEqual(0, _checkout.GetTotalPrice());
        }

        /// <summary>
        /// Verifies the total discounts applied.
        /// </summary>
        [Test]
        public void VerifyTotalDiscountsApplied()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.GetTotalPrice();
            Assert.AreEqual(20, _checkout.TotalDiscount);
        }

        /// <summary>
        /// Verifies the sub total before discounts applied.
        /// </summary>
        [Test]
        public void VerifySubTotalBeforeDiscountsApplied()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.GetTotalPrice();
            Assert.AreEqual(150, _checkout.SubTotal);
        }

        /// <summary>
        /// Verifies the total price property returns correct result.
        /// </summary>
        [Test]
        public void VerifyTotalPricePropertyReturnsCorrectResult()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.GetTotalPrice();
            Assert.AreEqual(130, _checkout.TotalPrice);
        }

        /// <summary>
        /// Verifies the total discounts not applied message.
        /// </summary>
        [Test]
        public void VerifyTotalDiscountsNotAppliedMessage()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.GetTotalPrice();
            Assert.AreEqual("You did not save any money on your shopping today.", _checkout.GetTotalDiscounts());
        }

        /// <summary>
        /// Verifies the total discounts applied message.
        /// </summary>
        [Test]
        public void VerifyTotalDiscountsAppliedMessage()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.GetTotalPrice();
            Assert.AreEqual("You saved £20 on your shopping today.", _checkout.GetTotalDiscounts());
        }

        [Test]
        public void VerifyDecimalDiscountTotalPriceIsCorrect()
        {
            _checkout.Scan("E");
            _checkout.Scan("E");
            _checkout.Scan("E");
            Assert.AreEqual(19.98m, _checkout.GetTotalPrice());
        }

        [Test]
        public void VerifyDecimalDiscountTotalDiscountsApplied()
        {
            _checkout.Scan("E");
            _checkout.Scan("E");
            _checkout.Scan("E");
            _checkout.GetTotalPrice();
            Assert.AreEqual("You saved £9.99 on your shopping today.", _checkout.GetTotalDiscounts());
        }
    }
}