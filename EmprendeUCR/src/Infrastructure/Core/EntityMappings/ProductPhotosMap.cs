using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class ProductPhotosMap : IEntityTypeConfiguration<ProductPhotos>
    {
        public void Configure(EntityTypeBuilder<ProductPhotos> builder)
        {
            builder.ToTable("Product_Photos");
            builder.HasKey(b => new { b.Code_ID, b.Category_ID, b.Entrepreneur_Email, b.Product_Photos_ID });

            builder.Property(e => e.Product_Photos_ID)
                .HasColumnName("Product_Photos_ID")
                .IsRequired();

            builder.Property(e => e.Code_ID)
                .HasColumnName("Code_ID")
                .IsRequired();

            builder.Property(e => e.Photos)
                .HasColumnName("Photos");

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