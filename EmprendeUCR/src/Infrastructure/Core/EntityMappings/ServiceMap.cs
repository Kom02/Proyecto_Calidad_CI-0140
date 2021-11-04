using Microsoft.EntityFrameworkCore;
using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(b => new { b.Entrepreneur_Email, b.Code_ID, b.Category_ID});

            builder.Property(e => e.Code_ID)
            .HasColumnName("Code_ID")
            .IsRequired();

            builder.Property(e => e.Entrepreneur_Email)
            .HasColumnName("Entrepreneur_Email")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(e => e.Category_ID)
            .HasColumnName("Category_ID")
            .IsRequired();

            builder.Property(e => e.Service_Name)
            .HasColumnName("Service_Name")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(e => e.Service_Description)
            .HasColumnName("Service_Description")
            .HasMaxLength(220);

            builder.Property(e => e.Price_per_hour)
            .HasColumnName("Price_per_hour");
        }
    }
}
