namespace Checkout.Data
{
	using System;
	using System.Collections.Generic;
	using Domain.Models;

	public class BasketRepository : IBasketRepository
    {
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

        public void AddProductItem(Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductItem(Product product)
        {
            throw new NotImplementedException();
        }

		public List<Product> GetBasketProducts(Guid basketId)
		{
			throw new NotImplementedException();
		}
	}
}