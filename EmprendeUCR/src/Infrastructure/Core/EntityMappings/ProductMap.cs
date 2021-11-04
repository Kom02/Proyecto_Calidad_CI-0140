using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(b => new { b.Code_ID, b.Entrepreneur_Email, b.Category_ID});

            builder.Property(e => e.Code_ID)
            .HasColumnName("Code_ID")
            .IsRequired();

            builder.Property(e => e.Product_Name)
            .HasColumnName("Product_Name")
            .HasMaxLength(100);

            builder.Property(e => e.Product_Description)
            .HasColumnName("Product_Description")
            .HasMaxLength(220);

            builder.Property(e => e.Price)
            .HasColumnName("Price");

            builder.Property(e => e.Entrepreneur_Email)
            .HasColumnName("Entrepreneur_Email")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(e => e.Category_ID)
            .HasColumnName("Category_ID")
            .IsRequired();
        }
    }
}