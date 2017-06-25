namespace Checkout.Data
{
	using System;
	using System.Collections.Generic;
	using Domain.Models;

	public class MockBasketRepository : IBasketRepository
	{
		private readonly Dictionary<Guid, List<Product>> _baskets;

		public MockBasketRepository()
		{
			var products1 = new List<Product>
			{
				new Product { Id = Guid.NewGuid() }
			};

			var products2 = new List<Product>
			{
				new Product { Id = Guid.NewGuid() }
			};

			var products3 = new List<Product>
			{
				new Product { Id = Guid.NewGuid() }
			};

			_baskets.Add(Guid.NewGuid(), products1);
			_baskets.Add(Guid.NewGuid(), products2);
			_baskets.Add(Guid.NewGuid(), products3);
		}

        public Basket GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

		public List<Product> GetBasketProducts(Guid basketId)
		{
			throw new NotImplementedException();
		}
	}
}