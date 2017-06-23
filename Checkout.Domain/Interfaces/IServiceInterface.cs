namespace Checkout.Domain.Interfaces
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Base interface that all WCF services should implement.
    /// </summary>
    [ServiceContract]
    public interface IServiceInterface
    {
        /// <summary>
        /// Provides basic heartbeat check to allow monitoring of service health.
        /// </summary>
        /// <returns>Current date and time.</returns>
        [OperationContract]
        DateTime Heartbeat();
    }
}