using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using EmprendeUCR.Domain.Entrepreneurs.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Entrepreneurs.EntityMappings
{
    public class ProductPhotoMap : IEntityTypeConfiguration<ProductPhotos>
    {
        public void Configure(EntityTypeBuilder<ProductPhotos> builder)
        {
            builder.ToTable("Product_Photos");
            builder.HasKey("Product_Photos_ID");

            builder.Property(e => e.Product_Photos_ID)
             .IsRequired()
             .HasColumnName("Product_Photos_ID");

            builder.HasOne(p => p.Product).WithMany(c => c.Photos).HasForeignKey("Code_ID");
        }
    }
}
