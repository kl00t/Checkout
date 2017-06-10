namespace Checkout.Data
{
	public class SpecialOffer : ISpecialOffer
	{
		public bool IsAvailable { get; set; }

		public int Quantity { get; set; }

		public int Discount { get; set; }
	}
}