using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as "Order" in the
 * context of the Shopping Cart.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext.EntityMappings
{
    public class IsOfferMap : IEntityTypeConfiguration<IsOffer>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Order" table, relating them to the 
         *          "Order" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<IsOffer> builder)
        {
            builder.HasKey(e => new { e.OfferId, e.CodeId, e.UserEmail, e.CategoryId });

            builder.ToTable("Is_Offer");

            builder.Property(e => e.OfferId).HasColumnName("Offer_ID");

            builder.Property(e => e.CodeId).HasColumnName("Code_ID");

            builder.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("User_Email");

            builder.Property(e => e.CategoryId).HasColumnName("Category_ID");

            builder.Property(e => e.Amount).HasDefaultValueSql("((1))");

            builder.HasOne(d => d.Offer)
                .WithMany(p => p.IsOffers)
                .HasForeignKey(d => d.OfferId);
        }
    }
}
