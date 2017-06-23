namespace Checkout.Service.Web
{

    using System.Collections.Generic;
    using Data;
    using Domain.Exceptions;
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
        public CheckoutService(ICheckout checkout, IProductRepository productRepository)
        {
            _checkout = checkout;
            _productRepository = productRepository;
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
        /// <returns>Returns a checkout response.</returns>
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
        /// <returns>Returns the checkout response.</returns>
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
        /// <returns>Returns the total price.</returns>
        public decimal TotalPrice()
        {
            return _checkout.GetTotalPrice();
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}