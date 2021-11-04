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
    class OfferMap : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");

            builder.HasKey("Offer_ID");

            builder.Property(e => e.Offer_ID)
                .IsRequired()
                .HasColumnName("Offer_ID");

            builder.Property(e => e.Initial_Date)
                .IsRequired()
                .HasColumnName("Initial_Date");

            builder.Property(e => e.Expire_Date)
               .IsRequired()
               .HasColumnName("Expire_Date");

            builder.Property(e => e.Offer_Description)
               .HasMaxLength(220)
               .HasColumnName("Offer_Description");
            builder.Property(e => e.Discount)
               .IsRequired()
               .HasColumnName("Discount");

        }
    }
}
