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
    class ShoppingCartHasMap : IEntityTypeConfiguration<ShoppingCartHas>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartHas> builder)
        {
            builder.ToTable("Shopping_Cart_Has");
            builder.HasKey(b => new { b.Category_ID, b.Code_ID, b.Entrepreneur_Email, b.Email});

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Code_ID)
                .HasColumnName("Code_ID")
                .IsRequired();

            builder.Property(e => e.Category_ID)
                .HasColumnName("Category_ID")
                .IsRequired();

            builder.Property(e => e.Entrepreneur_Email)
                .HasColumnName("Entrepreneur_Email")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}