using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as "Order" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Order" table, relating them to the 
         *          "Order" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => new { e.DateAndHourCreation, e.ClientEmail});

            builder.ToTable("Order");

            builder.Property(e => e.Details)
                .HasMaxLength(500);

            builder.Property(e => e.DeliveryDate).HasColumnName("Delivery_date");

            builder.Property(e => e.DeliveryAddress)
                .HasMaxLength(1000)
                .HasColumnName("Delivery_Address");

            builder.Property(e => e.EntrepreneurEmail)
                .HasMaxLength(100).HasColumnName("Entrepreneur_Email");

            builder.Property(e => e.DateAndHourCreation)
                .HasColumnName("Date_and_hour_of_creation");

            builder.Property(d => d.ClientEmail).HasColumnName("Client_Email")
                .HasMaxLength(100);

            builder.Property(e => e.State)
                .HasMaxLength(30)
                .HasColumnName("State");

            builder.Property(e => e.PaymentName)
                .HasMaxLength(30)
                .HasColumnName("Payment_Name");

            builder.HasMany(d => d.Organized)
                .WithOne(p => p.order).IsRequired();

            builder.HasOne(e => e.genericStatus)
                .WithMany(s => s.Order)
                .HasForeignKey(e => new { e.State });

        }
    }
}
