using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class ActiveAdministratorsMap : IEntityTypeConfiguration<ActiveAdministrators>
    {
        public void Configure(EntityTypeBuilder<ActiveAdministrators> builder)
        {
            builder.ToTable("ActiveAdministrators")
                .HasKey(admin => admin.Email);

            builder.Property(admin => admin.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email");

            builder.Property(admin => admin.Creation_Date)
                .IsRequired()
                .HasColumnName("Creation_Date");

            builder.Property(admin => admin.Response)
                .IsRequired()
                .HasColumnName("Response");

            builder.Property(admin => admin.Confirm)
                .IsRequired()
                .HasColumnName("Confirm");

            builder.Property(admin => admin.Active)
                .IsRequired()
                .HasColumnName("Active");

            builder.Property(admin => admin.Response_Date)
                .HasColumnName("Response_Date");
        }
    }
}
