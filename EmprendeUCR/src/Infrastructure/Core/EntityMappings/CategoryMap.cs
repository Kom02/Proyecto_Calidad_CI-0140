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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(e => new { e.Id});

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.ParentId)
                .HasColumnName("ParentId");

            builder.Property(e => e.Title)
                .HasColumnName("Title") 
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(50);
        }
    }
}