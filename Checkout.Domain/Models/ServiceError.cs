namespace Checkout.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Capita Service Error.
    /// </summary>
    [Serializable]
    [DataContract]
    public enum ServiceError
    {
        /// <summary>
        /// The none.
        /// </summary>
        [EnumMember]
        None,

        /// <summary>
        /// The unknown.
        /// </summary>
        [EnumMember]
        Unknown,

        /// <summary>
        /// The invalid product.
        /// </summary>
        [EnumMember]
        InvalidProduct,

        /// <summary>
        /// The invalid argument
        /// </summary>
        [EnumMember]
        InvalidArgument
    }
}