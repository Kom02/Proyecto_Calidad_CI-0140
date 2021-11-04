using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as "Has_Status" in
 * the context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class ProductHasStatusMap : IEntityTypeConfiguration<ProductHasStatus>
    {
        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Has_Status" table, relating them to the
         *          "ProductHasStatus" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<ProductHasStatus> builder)
        {
            builder.HasKey(e => new { e.Name, e.CodeId, e.EntrepreneurEmail, e.CategoryId });

            builder.ToTable("Has_Status");

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("Name");

            builder.Property(e => e.CodeId)
                .HasColumnName("Code_ID");

            builder.Property(e => e.EntrepreneurEmail)
                .HasMaxLength(100)
                .HasColumnName("Entrepreneur_Email");

            builder.Property(e => e.CategoryId)
                .HasColumnName("Category_ID");

            builder.Property(e => e.Order)
                .HasColumnName("Order");

            builder.HasOne(e => e.personalizedStatus)
                .WithMany(s => s.ProductHasStatus)
                .HasForeignKey(e => new { e.Name });

            builder.HasOne(e => e.productService)
                .WithMany(p => p.ProductHasStatus)
                .HasForeignKey(e => new { e.CodeId, e.EntrepreneurEmail, e.CategoryId });
        }
    }
}
