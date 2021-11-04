using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to implement the map of the table knows as "Product" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Product" table, relating them to the 
         *          "Product" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
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

            builder.Ignore(e => e.ShoppingCartHas);
            builder.Ignore(e => e.Product_Photos);
            builder.Ignore(e => e.currentPrice);
        }
    }
}
