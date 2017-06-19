namespace Checkout.Service.Web
{
    /// <summary>
    /// Checkout response interface.
    /// </summary>
    public interface ICheckoutResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is scan successful.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is scan successful; otherwise, <c>false</c>.
        /// </value>
        bool IsScanSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        string Error { get; set; }
    }
}