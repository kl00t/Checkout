namespace Checkout.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using Domain.Models;

    public class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            this.ToTable("Product")
                .HasKey<Guid>(k => k.Id)
                .HasRequired(s => s.SpecialOffer)
                .WithRequiredPrincipal(p => p.Product)
                .WillCascadeOnDelete(true);

            this.Property(p => p.Sku)
                .HasMaxLength(1)
                .IsRequired();

            this.Property(p => p.Description)
                .HasMaxLength(50)
                .IsFixedLength()
                .IsRequired();

            this.Property(p => p.UnitPrice)
                .IsRequired();
        }
    }
}