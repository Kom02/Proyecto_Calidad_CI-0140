using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("District");

            builder.HasKey(e => new { e.Name, e.Province_Name, e.Canton_Name } );

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(e => e.Province_Name)
                .HasColumnName("Province_Name")
                .IsRequired();

            builder.Property(e => e.Canton_Name)
                .HasColumnName("Canton_Name")
                .IsRequired();
        }
    }
}
