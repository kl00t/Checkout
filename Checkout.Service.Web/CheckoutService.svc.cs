namespace Checkout.Service.Web
{
    using Core;
    using Data;

    public class CheckoutService : BaseService, ICheckoutService
    {
        private readonly ICheckout _checkout;

        public CheckoutService(ICheckout checkout)
        {
            _checkout = checkout;
        }

        public CheckoutService()
        {
        }

        public CheckoutResponse Scan(string item)
        {
            try
            {
                _checkout.Scan(item);
                return new CheckoutResponse
                {
                    IsScanSuccessful = true
                };
            }
            catch (InvalidProductException invalidProduct)
            {
                return new CheckoutResponse
                {
                    IsScanSuccessful = true,
                    Error = invalidProduct.Message
                };
            }
        }

        public CheckoutResponse CancelScan(string item)
        {
            try
            {
                _checkout.CancelScan(item);
                return new CheckoutResponse
                {
                    IsScanSuccessful = true
                };
            }
            catch (InvalidProductException invalidProduct)
            {
                // TODO: Invoke the exception handling in a base class.
                return new CheckoutResponse
                {
                    IsScanSuccessful = true,
                    Error = invalidProduct.Message
                };
            }
        }

        public decimal TotalPrice()
        {
            return _checkout.GetTotalPrice();
        }
    }
}