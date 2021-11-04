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
    public class ProductServiceMap : IEntityTypeConfiguration<ProductService>
    {
        public void Configure(EntityTypeBuilder<ProductService> builder)
        {
            builder.ToTable("Product_Service");

            builder.HasKey("Code_ID");

            builder.Property(e => e.Code_ID)
             .IsRequired()
             .HasColumnName("Code_ID");

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
