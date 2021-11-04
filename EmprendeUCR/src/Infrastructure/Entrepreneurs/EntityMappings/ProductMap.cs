using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using EmprendeUCR.Domain.Entrepreneurs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Entrepreneurs.EntityMappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(t => t.Code_ID);

            builder.Property(t => t.Product_Name)
                .HasConversion(r => r.Value,
                    s => RequiredProductName.TryCreate(s).Success());

            builder.Property(t => t.Product_Description)
                .HasConversion(r => r.Value,
                    s => RequiredProductDescription.TryCreate(s).Success());


            builder.Property(p => p.Price);

        }
    }
}
