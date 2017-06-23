namespace Checkout.Data
{
    using System;
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

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }
    }
}