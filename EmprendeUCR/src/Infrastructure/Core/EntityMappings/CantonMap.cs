using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class CantonMap : IEntityTypeConfiguration<Canton>
    {
        public void Configure(EntityTypeBuilder<Canton> builder)
        {
            builder.ToTable("Canton");

            builder.HasKey(e => new { e.Name, e.Province_Name} );

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(e => e.Province_Name)
                .HasColumnName("Province_Name")
                .IsRequired();
        }
    }
}
