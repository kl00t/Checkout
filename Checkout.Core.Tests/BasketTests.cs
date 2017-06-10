namespace Checkout.Core.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class BasketTests
	{
		[SetUp]
		public void SetUp()
		{

		}

		[Test]
		public void VerifyNewBasketContainsEmptyItems()
		{
			var basket = new Basket();
			Assert.IsNotNull(basket.Products);
		}

		[Test]
		[Ignore]
		public void VerifyHowManyItemsInBasket()
		{
			// TODO: To Be implemented
		}
	}
}
