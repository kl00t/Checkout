namespace Checkout.Core
{
	public interface ICarrierBag
	{
		decimal Charge { get; set; }

		decimal CalculateBagCharge(int numberOfItems);
	}
}
