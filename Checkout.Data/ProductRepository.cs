namespace Checkout.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products; 

        public ProductRepository()
        {
			_products = new List<Product>();
        }

        public IEnumerable<Product> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Product SelectById(int id)
        {
            return _products.First(x => x.Id == id);
        }

        public void Insert(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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