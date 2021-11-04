using EmprendeUCR_WebApplication.Domain.NotificationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.EntitityMappings
{
    public class OrderNotificationEntrepeneurMap : IEntityTypeConfiguration<OrderNotificationEntrepeneur>
    {
        public void Configure(EntityTypeBuilder<OrderNotificationEntrepeneur> builder)
        {
            builder.HasKey(e => new { e.DateAndHourCreation, e.ClientEmail });

            builder.ToView("OrderNotificationEntrepeneurs");

            builder.Property(d => d.ClientEmail).HasColumnName("Client_Email")
                .HasMaxLength(100);
            builder.Property(d => d.DateAndHourCreation).HasColumnName("Date_and_hour_of_creation");

            builder.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("State");
            builder.Property(e => e.EntrepreneurEmail)
              .HasMaxLength(100).HasColumnName("Entrepreneur_Email");
            builder.Property(e => e.nameClient).HasColumnName("Name");
            builder.Property(d => d.date).HasColumnName("Date_and_hour_of_State_Changed");

            // Builder ignore from inherited class
            builder.Ignore(e => e.color);
            builder.Ignore(e => e.Type);
            builder.Ignore(e => e.url);
        }
    }
}
