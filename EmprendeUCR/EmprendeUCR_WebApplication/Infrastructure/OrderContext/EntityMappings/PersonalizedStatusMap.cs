using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used to implement the map of the table knows as 
 * "Personalized_Status" in the context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class PersonalizedStatusMap : IEntityTypeConfiguration<PersonalizedStatus>
    {
        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Personalized_Status" table, relating
         *          them to the "PersonalizedStatus" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<PersonalizedStatus> builder)
        {
            builder.HasKey(e => new { e.Name });

            builder.ToTable("Personalized_Status");

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("Name");

            builder.HasOne(e => e.status)
                .WithOne(s => s.personalizedStatus)
                .HasForeignKey<PersonalizedStatus>(e => new { e.Name });

        }
    }
}
