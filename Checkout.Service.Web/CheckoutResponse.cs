namespace Checkout.Service.Web
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Checkout response object.
    /// </summary>
    /// <seealso cref="Checkout.Service.Web.ICheckoutResponse" />
    [DataContract]
    [Serializable]
    public class CheckoutResponse : ICheckoutResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is scan successful.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is scan successful; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsScanSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [DataMember]
        public string Error { get; set; }
    }
}