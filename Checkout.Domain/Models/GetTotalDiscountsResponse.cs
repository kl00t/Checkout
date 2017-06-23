namespace Checkout.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    public class GetTotalDiscountsResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        /// <value>
        /// The total discount.
        /// </value>
        [DataMember]
        public string TotalDiscount { get; set; }
    }
}