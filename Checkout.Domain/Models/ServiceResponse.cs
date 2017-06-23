namespace Checkout.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Checkout response object.
    /// </summary>
    [DataContract]
    [Serializable]
    public class ServiceResponse<T>
    {
        /// <summary>
        /// The error, if any, which occurred when calling this service.
        /// </summary>
        private ServiceError _error = ServiceError.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        public ServiceResponse()
        {
            IsSuccessful = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public ServiceResponse(T response)
        {
            Response = response;
            Error = ServiceError.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="error">The error.</param>
        public ServiceResponse(T response, ServiceError error)
        {
            Response = response;
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ServiceResponse(ServiceError error)
        {
            Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponse{T}"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public ServiceResponse(T response, bool success)
        {
            Response = response;
            IsSuccessful = success;
        }

        /// <summary>
        /// Gets or sets the actual response content.
        /// </summary>
        /// <value>
        /// The response content.
        /// </value>
        [DataMember]
        public T Response { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the service call was successful.
        /// </summary>
        /// <value>
        /// Was the service call successful.
        /// </value>
        [DataMember]
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the error that occurred during the web service call.
        /// </summary>
        /// <value>
        /// The type of error which occured.
        /// </value>
        [DataMember]
        public ServiceError Error
        {
            get
            {
                return _error;
            }

            set
            {
                _error = value;
                IsSuccessful = _error == ServiceError.None;
            }
        }
    }
}