using EmprendeUCR_WebApplication.Domain.NotificationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext.EntitityMappings
{
    public class OrderNotificationClientMap : IEntityTypeConfiguration<OrderNotificationClient>
    {
        public void Configure(EntityTypeBuilder<OrderNotificationClient> builder)
        {

            builder.HasKey(e => new { e.DateAndHourCreation, e.ClientEmail });

            builder.ToView("OrderNotificationClient");

            builder.Property(d => d.ClientEmail).HasColumnName("Client_Email")
                .HasMaxLength(100);
            builder.Property(d => d.DateAndHourCreation).HasColumnName("Date_and_hour_of_creation");
            builder.Property(e => e.State)
                .HasMaxLength(20)
                .HasColumnName("State");
            builder.Property(e => e.NameEntrepenur).HasColumnName("Name");
            builder.Property(d => d.date).HasColumnName("Date_and_hour_of_State_Changed");
            builder.Property(d => d.view).HasColumnName("view");
            // Builder ignore from inherited class
            builder.Ignore(e => e.url);
            builder.Ignore(e => e.color);
            builder.Ignore(e => e.Type);
        }
    }
}
