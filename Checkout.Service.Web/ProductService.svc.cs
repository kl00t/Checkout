namespace Checkout.Service.Web
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Core.Framework;
    using Core.Logging;
    using Data;
    using Domain.Models;

    public class ProductService : BaseService, IProductService
    {
        /// <summary>
        /// The product repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutService" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">checkout
        /// or
        /// productRepository</exception>
        public ProductService(IProductRepository productRepository, ILogger logger) : base(logger)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException("productRepository");
            }

            _productRepository = productRepository;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public ServiceResponse<AddProductResponse> AddProduct(Product product)
		{
			return CallEngine(
				() => _productRepository.AddProduct(product),
				EventType.AddProduct);
		}

		/// <summary>
		/// Gets all products.
		/// </summary>
		/// <returns>
		/// Returns all products.
		/// </returns>
		public ServiceResponse<List<Product>> GetAllProducts()
        {
            return CallEngine(
                () => _productRepository.GetAllProducts(),
                EventType.GetAllProducts);
        }
	}
}