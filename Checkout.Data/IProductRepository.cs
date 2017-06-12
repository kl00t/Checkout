namespace Checkout.Data
{
    /// <summary>
    /// Product repository interface definition.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Inserts the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Insert(Product product);

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Update(Product product);

        /// <summary>
        /// Deletes the specified sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        void Delete(string sku);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();

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
        int GetProductUnitPrice(string skuCode);
    }
}