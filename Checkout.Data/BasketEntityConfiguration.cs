namespace Checkout.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using Domain.Models;

    public class BasketEntityConfiguration : EntityTypeConfiguration<Basket>
    {
        public BasketEntityConfiguration()
        {
            this.ToTable("Basket")
                .HasKey<Guid>(k => k.Id);
        }
    }
}