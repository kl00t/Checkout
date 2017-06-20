namespace Checkout.Data
{
    /// <summary>
    /// Product repository interface definition.
    /// </summary>
    public interface IProductRepository : IRepository<Product, string>
    {
        /// <summary>
        /// Gets the product by sku code.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>Returns the product by the sku code.</returns>
        Product GetProductBySkuCode(string skuCode);

        /// <summary>
        /// Gets the product unit price.
        /// </summary>
        /// <param name="skuCode">The sku code.</param>
        /// <returns>Returns the product unit price by the sku code.</returns>
        decimal GetProductUnitPrice(string skuCode);
    }
}