namespace Checkout.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    public class GetTotalPriceResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        [DataMember]
        public decimal TotalPrice { get; set; }
    }
}