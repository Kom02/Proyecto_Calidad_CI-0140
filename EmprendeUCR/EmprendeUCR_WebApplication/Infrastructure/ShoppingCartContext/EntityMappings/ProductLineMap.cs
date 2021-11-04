using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;

/* This file is used to implement the map of the table knows as
 * "Shopping_Cart_Has" in the context of the Shopping Cart, the name in this
 * project was changed to "ShopLine".
 */
namespace EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext.EntityMappings
{
    public class ProductLineMap : IEntityTypeConfiguration<ShopLine>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Shopping_Cart_Has" table, relating them 
         *          to the "ShopLine" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<ShopLine> builder)
        {
            builder.HasKey(e => new { e.Email, e.CodeId, e.EntrepreneurEmail, e.CategoryId });

            builder.ToTable("Shopping_Cart_Has");

            builder.Property(e => e.Email)
                .HasMaxLength(100);

            builder.Property(e => e.CodeId).HasColumnName("Code_ID");

            builder.Property(e => e.EntrepreneurEmail)
                .HasMaxLength(100)
                .HasColumnName("Entrepreneur_Email");


           builder.Property(e => e.CategoryId).HasColumnName("Category_ID");

            builder.HasOne(d => d.shoppingCart)
                .WithMany(p => p.ShopLines)
                .HasForeignKey(d => d.Email);


            builder.HasOne(d => d.product)
                .WithMany(d => d.ShoppingCartHas)
                .HasForeignKey(d => new { d.CodeId, d.EntrepreneurEmail, d.CategoryId });

            builder.Ignore(s => s.Quantity);

        }
    }
}
