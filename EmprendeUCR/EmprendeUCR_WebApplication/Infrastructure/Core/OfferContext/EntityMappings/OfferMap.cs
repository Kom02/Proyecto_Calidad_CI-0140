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
    public class OfferMap : IEntityTypeConfiguration<Offer>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Order" table, relating them to the 
         *          "Order" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            builder.HasKey(e => new { e.OfferId });

            builder.Property(e => e.OfferId).HasColumnName("Offer_ID");

            builder.Property(e => e.ExpireDate)
                .HasColumnType("date")
                .HasColumnName("Expire_Date");

            builder.Property(e => e.InitialDate)
                .HasColumnType("date")
                .HasColumnName("Initial_Date");

            builder.Property(e => e.OfferDescription)
                .HasMaxLength(220)
                .IsUnicode(false)
                .HasColumnName("Offer_Description");
        }
    }
}
