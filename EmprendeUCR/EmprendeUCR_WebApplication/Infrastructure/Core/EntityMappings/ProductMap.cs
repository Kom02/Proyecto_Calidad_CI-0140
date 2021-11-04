using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

namespace EmprendeUCR_WebApplication.Infrastructure.Core.EntityMappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");

            builder.Property(e => e.ProductDescription)
                .HasMaxLength(220)
                .HasColumnName("Product_Description");

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Product_Name");
            builder.HasMany(e => e.ShoppingCartHas)
                   .WithOne(c => c.product!);

        }
    }
}
