namespace Checkout.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Domain.Interfaces;
    using Domain.Models;

    /// <summary>
    /// Product service contract.
    /// </summary>
    [ServiceContract]
    public interface IProductService : IServiceInterface
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>
        /// Returns all products.
        /// </returns>
        [OperationContract]
        ServiceResponse<List<Product>> GetAllProducts();
    }
}