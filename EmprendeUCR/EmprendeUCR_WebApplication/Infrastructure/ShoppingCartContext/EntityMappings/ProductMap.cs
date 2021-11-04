using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to implement the map of the table knows as "Product" in
 * the context of the Shopping Cart.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext.EntityMappings
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

            builder.HasMany(e => e.ShoppingCartHas)
                   .WithOne(c => c.product!);

            builder.HasMany(e => e.Product_Photos)
                   .WithOne(c => c.product!)
                   .HasForeignKey(e => new { e.Code_ID, e.Entrepreneur_Email , e.Category_ID });
            builder.Ignore(p => p.currentPrice);
        }
    }
}
