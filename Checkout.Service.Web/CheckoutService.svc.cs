namespace Checkout.Service.Web
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Core;
    using Core.Framework;
    using Core.Logging;
    using Data;
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
        /// The product repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutService" /> class.
        /// </summary>
        /// <param name="checkout">The checkout.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// checkout
        /// or
        /// productRepository
        /// </exception>
        public CheckoutService(ICheckout checkout, IProductRepository productRepository, ILogger logger) : base(logger)
        {
            if (checkout == null)
            {
                throw new ArgumentNullException("checkout");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("productRepository");
            }

            _checkout = checkout;
            _productRepository = productRepository;
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

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        public ServiceResponse<List<Product>> GetAllProducts()
        {
            return CallEngine(
                () => _productRepository.GetAllProducts(),
                EventType.GetAllProducts);
        }
    }
}