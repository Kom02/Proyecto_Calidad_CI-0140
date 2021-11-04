using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as "Organized" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class OrganizedMap : IEntityTypeConfiguration<Organized>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Organized" table, relating them to the
         *          "Organized" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Organized> builder)
        {
            builder.HasKey(e => new { e.CodeId, e.EntrepreneurEmail, e.CategoryId,
                                      e.DateAndHourCreation, e.Email}); // Name is not a key in this mapping
            builder.ToTable("Organized");

            builder.Property(e => e.EntrepreneurEmail)
                .HasMaxLength(100).HasColumnName("Entrepreneur_Email");

            builder.Property(e => e.Email)
                .HasMaxLength(100).HasColumnName("Email");

            builder.Property(e => e.Name)
                .HasMaxLength(30).IsRequired();

            builder.Property(e => e.DateAndHourCreation).HasColumnName("Date_and_hour_of_creation");

            builder.Property(e => e.DateOfChange).HasColumnName("Date_of_Change");

            builder.Property(e => e.CodeId).HasColumnName("Code_ID");

            builder.Property(e => e.CategoryId).HasColumnName("Category_ID");


            builder.HasOne(d => d.order)
                .WithMany(p => p.Organized)
                .HasForeignKey(d => new { d.DateAndHourCreation, d.Email }).IsRequired();

            builder.HasOne(d => d.status)
                .WithMany(p => p.Organized)
                .HasForeignKey(d => new { d.Name});

            builder.HasOne(d => d.productService)
                .WithMany(p => p.Organized)
                .HasForeignKey(d => new { d.CodeId, d.EntrepreneurEmail, d.CategoryId });
        }
    }
}
