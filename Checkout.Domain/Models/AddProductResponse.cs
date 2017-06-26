namespace Checkout.Domain.Models
{
	using System;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class AddProductResponse : ResponseBase
	{
		[DataMember]
		public Guid ProductId { get; set; }
	}
}