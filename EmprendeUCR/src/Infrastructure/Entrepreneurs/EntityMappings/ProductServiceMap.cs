using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;

namespace EmprendeUCR.Infrastructure.Entrepreneurs.EntityMappings
{
    public class ProductServiceMap : IEntityTypeConfiguration<Product_Service>
    {
        public void Configure(EntityTypeBuilder<Product_Service> builder)
        {
            builder.ToTable("Product_Service");

            builder.HasKey("Code_ID");

            builder.Property(e => e.Code_ID)
             .IsRequired()
             .HasColumnName("Code_ID");

            builder.HasOne(p => p.Category).WithMany(c => c.ProductServices).HasForeignKey("Category_ID");

            //builder.Property(c => c.Category).HasConversion(u => u.Id,Categorie{id});

            //builder.HasMany(t => t.Roster).WithOne(p => p.Team!);


            //builder.Property(e => e.Entrepreneur_Email)
            //    .IsRequired()
            //    .HasMaxLength(100)
            //    .HasColumnName("Entrepreneur_Email");

            //builder.Property(e => e.Availability)
            // .IsRequired()
            // .HasColumnName("Availability");

            //builder.Property(e => e.Category_ID)
            // .IsRequired()
            // .HasColumnName("Category_ID");




        }
    }
}