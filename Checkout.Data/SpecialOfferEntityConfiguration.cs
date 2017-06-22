namespace Checkout.Data
{

    using System;
    using System.Data.Entity.ModelConfiguration;
    using Domain.Models;

    public class SpecialOfferEntityConfiguration : EntityTypeConfiguration<SpecialOffer>
    {
        public SpecialOfferEntityConfiguration()
        {
            this.ToTable("SpecialOffer")
                .HasKey<Guid>(k => k.Id);

            this.Property(p => p.IsAvailable)
                .IsRequired();

            this.Property(p => p.Quantity);
            this.Property(p => p.Discount);
        }
    }
}