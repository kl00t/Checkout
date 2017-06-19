namespace Checkout.Service.Web
{
    using Core;
    using Data;

    /// <summary>
    /// Checkout WCF Service.
    /// </summary>
    public class CheckoutService : BaseService, ICheckoutService
    {
        /// <summary>
        /// The checkout
        /// </summary>
        private readonly ICheckout _checkout;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutService"/> class.
        /// </summary>
        /// <param name="checkout">The checkout.</param>
        public CheckoutService(ICheckout checkout)
        {
            _checkout = checkout;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutService"/> class.
        /// </summary>
        public CheckoutService()
        {
        }

        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Cancels the scan.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Totals the price.
        /// </summary>
        /// <returns></returns>
        public decimal TotalPrice()
        {
            return _checkout.GetTotalPrice();
        }
    }
}