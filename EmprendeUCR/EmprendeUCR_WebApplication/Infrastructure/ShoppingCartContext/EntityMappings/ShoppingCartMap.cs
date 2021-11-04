using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;

/* This file is used to implement the map of the table knows as "Shopping_Cart"
 * in the context of the Shopping Cart.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext.EntityMappings
{
    public class ShoppingCartMap : IEntityTypeConfiguration<ShoppingCart>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Shopping_Cart" table, relating them to 
         *          the "Shopping_Cart" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(e => e.Email)
                   .HasName("PK__Shopping__A9D10535B2BE1623");

            builder.ToTable("Shopping_Cart");

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            
            builder.HasMany(e => e.ShopLines)
                .WithOne(c => c.shoppingCart!);
        }
    }
}
