namespace Checkout.Contracts
{
    using System.ServiceModel;
    using Domain.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Checkout service contract.
    /// </summary>
    [ServiceContract]
    public interface ICheckoutService : IServiceInterface
    {
        /// <summary>
        /// Scans the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Returns a checkout response.</returns>
        [OperationContract]
        ServiceResponse<ScanResponse> Scan(string item);

        /// <summary>
        /// Cancels the scan.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Returns a checkout response.</returns>
        [OperationContract]
        ServiceResponse<CancelScanResponse> CancelScan(string item);

        /// <summary>
        /// Totals the price.
        /// </summary>
        /// <returns>Returns the total price.</returns>
        [OperationContract]
        ServiceResponse<GetTotalPriceResponse> GetTotalPrice();
    }
}