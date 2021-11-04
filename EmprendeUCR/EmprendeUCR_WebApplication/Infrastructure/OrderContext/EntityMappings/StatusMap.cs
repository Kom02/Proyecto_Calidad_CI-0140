using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as "Status" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Status" table, relating them to the
         *          "Status" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(e => new { e.Name });

            builder.ToTable("Status");

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("Name");

            builder.Property(e => e.PreviousStateName)
                .HasMaxLength(30)
                .HasColumnName("Previous_State_Name");

            builder.HasOne(e => e.previousStatus)
                .WithOne(s => s.posteriorStatus)
                .HasForeignKey<Status>(e => new { e.PreviousStateName });

        }
    }
}
