using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to implement the map of the table knows as "Service" in
 * the context of the Shopping Cart.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext.EntityMappings
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "Service" table, relating them to the
         *          "Service" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<Service> builder)
        {

            builder.ToTable("Service");

            builder.Property(e => e.PricePerHour).HasColumnName("Price_per_hour");

            builder.Property(e => e.ServiceDescription)
                .HasMaxLength(220)
                .IsUnicode(false)
                .HasColumnName("Service_Description");

            builder.Property(e => e.ServiceName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Service_Name");
        }
    }
}
