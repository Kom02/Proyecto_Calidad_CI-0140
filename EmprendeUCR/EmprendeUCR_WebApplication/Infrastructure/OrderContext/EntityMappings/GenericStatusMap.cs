using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as 
 * "Generic_Status" in the context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class GenericStatusMap : IEntityTypeConfiguration<GenericStatus>
    {
        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Generic_Status" table, relating
         *          them to the "GenericStatus" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<GenericStatus> builder)
        {
            builder.HasKey(e => new { e.Name });

            builder.ToTable("Generic_Status");

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("Name");

            builder.HasOne(e => e.status)
                .WithOne(s => s.genericStatus)
                .HasForeignKey<GenericStatus>(e => new { e.Name });
        }
    }
}
