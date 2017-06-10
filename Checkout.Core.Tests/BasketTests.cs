namespace Checkout.Core.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class BasketTests
	{
		private Basket _basket;

		[SetUp]
		public void SetUp()
		{
			_basket = new Basket();
		}

		[Test]
		public void VerifyNewBasketContainsEmptyItems()
		{
			Assert.IsNotNull(_basket.Products);
		}

		[Test]
		public void VerifyHowManyItemsInBasket()
		{
			_basket.Products.Add(new Data.Product
			{
				Id = 1,
				Sku = "A",
				Description = "Pineapple",
				UnitPrice = 40
			});

			Assert.AreEqual(1, _basket.Products.Count);
		}
	}
}
