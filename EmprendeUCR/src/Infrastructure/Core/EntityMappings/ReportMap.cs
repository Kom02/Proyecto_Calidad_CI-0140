using EmprendeUCR.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Reports.Entities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");

            builder.HasKey(e => new { e.ID });

            builder.Property(e => e.ID)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.User)
                .HasColumnName("user");

            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Content)
                .HasColumnName("Content")
                .HasMaxLength(5000);
        }
    }
}