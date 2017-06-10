namespace Checkout.Data
{
	public interface ISpecialOffer
	{
		bool IsAvailable { get; set; }

		int Quantity { get; set; }

		int Discount { get; set; }
	}
}