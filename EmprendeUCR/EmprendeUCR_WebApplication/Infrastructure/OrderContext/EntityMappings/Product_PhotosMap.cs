using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to implement the map of the table knows as "Product_Photos" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class Product_PhotosMap : IEntityTypeConfiguration<Product_Photos>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Product_Photos" table, relating them to
         *          the "Product_Photos" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Product_Photos> builder)
        {

            builder.HasKey(e => new { e.Product_Photos_ID, e.Code_ID, e.Entrepreneur_Email, e.Category_ID });

            builder.ToTable("Product_Photos");

            builder.Property(e => e.Product_Photos_ID)
                .IsRequired()
                .HasColumnName("Product_Photos_ID");

            builder.Property(e => e.Code_ID)
                .IsRequired()
                .HasColumnName("Code_ID");

            builder.Property(e => e.Entrepreneur_Email)
                .HasMaxLength(110)
                .HasColumnName("Entrepreneur_Email");

            builder.Property(e => e.Photos)
                .HasColumnName("Photos");

            builder.Property(e => e.Category_ID)
                .IsRequired()
                .HasColumnName("Category_ID");

            builder.HasOne(e => e.product)
                   .WithMany(c => c.Product_Photos)
                   .HasForeignKey(e => new { e.Code_ID, e.Entrepreneur_Email, e.Category_ID });
        }
    }
}
