namespace Checkout.Data
{
    using System;
    using System.Runtime.Serialization;

    public class InvalidProductException : Exception
    {
        public InvalidProductException()
        {
        }

        public InvalidProductException(string message) : base(message)
        {
        }

        public InvalidProductException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}