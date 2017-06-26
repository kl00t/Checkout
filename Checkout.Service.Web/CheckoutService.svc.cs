namespace Checkout.Service.Web
{
    using System;
    using Contracts;
    using Core.Framework;
    using Core.Logging;
    using Domain.Interfaces;
    using Domain.Models;

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
        /// Initializes a new instance of the <see cref="CheckoutService" /> class.
        /// </summary>
        /// <param name="checkout">The checkout.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">checkout
        /// or
        /// productRepository</exception>
        public CheckoutService(ICheckout checkout, ILogger logger) : base(logger)
        {
            if (checkout == null)
            {
                throw new ArgumentNullException("checkout");
            }

            _checkout = checkout;
        }

        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// Returns a checkout response.
        /// </returns>
        public ServiceResponse<ScanResponse> Scan(string item)
        {
            return CallEngine(
                () => _checkout.Scan(item),
                EventType.ScanItem);
        }

        /// <summary>
        /// Cancels the scan.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// Returns a checkout response.
        /// </returns>
        public ServiceResponse<CancelScanResponse> CancelScan(string item)
        {
            return CallEngine(
                () => _checkout.CancelScan(item),
                EventType.CancelScanItem);
        }

        /// <summary>
        /// Totals the price.
        /// </summary>
        /// <returns>
        /// Returns the total price.
        /// </returns>
        public ServiceResponse<GetTotalPriceResponse> GetTotalPrice()
        {
            return CallEngine(
                () => _checkout.GetTotalPrice(),
                EventType.GetTotalPrice);
        }
    }
}