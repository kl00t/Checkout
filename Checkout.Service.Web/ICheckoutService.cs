namespace Checkout.Service.Web
{

    using System.Collections.Generic;
    using System.ServiceModel;
    using Domain.Models;

    /// <summary>
    /// Checkout service contract.
    /// </summary>
    [ServiceContract]
    public interface ICheckoutService
    {
        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Returns a checkout response.</returns>
        [OperationContract]
        CheckoutResponse Scan(string item);

        /// <summary>
        /// Cancels the scan.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Returns a checkout response.</returns>
        [OperationContract]
        CheckoutResponse CancelScan(string item);

        /// <summary>
        /// Totals the price.
        /// </summary>
        /// <returns>Returns the total price.</returns>
        [OperationContract]
        decimal TotalPrice();

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        [OperationContract]
        List<Product> GetAllProducts();
    }
}