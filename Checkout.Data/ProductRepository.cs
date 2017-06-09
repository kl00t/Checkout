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
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Sku = "A",
                    UnitPrice = 50
                },
                new Product
                {
                    Id = 2,
                    Sku = "B",
                    UnitPrice = 30
                }
                ,
                new Product
                {
                    Id = 3,
                    Sku = "C",
                    UnitPrice = 20
                },
                new Product
                {
                    Id = 4,
                    Sku = "D",
                    UnitPrice = 15
                }
            };
        }

        public IEnumerable<Product> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Product SelectById(int id)
        {
            throw new NotImplementedException();
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

        public int GetProductUnitPrice(string skuCode)
        {
            return _products.Find(x => x.Sku == skuCode).UnitPrice;
        }
    }
}