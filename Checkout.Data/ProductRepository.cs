namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Checkout.Data.IProductRepository" />
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products; 

        public ProductRepository()
        {
			_products = new List<Product>();
        }

        public void Insert(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(string sku)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

		public Product GetProductBySkuCode(string skuCode)
		{
			var product = _products.Find(x => x.Sku == skuCode);
			if (product == null)
			{
				throw new InvalidProductException();
			}

			return product;
		}

        public int GetProductUnitPrice(string skuCode)
        {
            return GetProductBySkuCode(skuCode).UnitPrice;
        }
    }
}