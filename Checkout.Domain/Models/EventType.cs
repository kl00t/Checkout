namespace Checkout.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    public enum EventType
    {
        /// <summary>
        /// The event type is not specified.
        /// </summary>
        [EnumMember]
        NotSpecified,

        /// <summary>
        /// The scan item
        /// </summary>
        [EnumMember]
        ScanItem,

        /// <summary>
        /// The scan item
        /// </summary>
        [EnumMember]
        CancelScanItem,

        /// <summary>
        /// The performance timing
        /// </summary>
        [EnumMember]
        PerformanceTiming,

        /// <summary>
        /// The get total price
        /// </summary>
        [EnumMember]
        GetTotalPrice,

        /// <summary>
        /// The get all products
        /// </summary>
        [EnumMember]
        GetAllProducts
    }
}