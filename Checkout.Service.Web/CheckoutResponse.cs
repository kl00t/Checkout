namespace Checkout.Service.Web
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    public class CheckoutResponse : ICheckoutResponse
    {
        [DataMember]
        public bool IsScanSuccessful { get; set; }

        [DataMember]
        public string Error { get; set; }
    }
}