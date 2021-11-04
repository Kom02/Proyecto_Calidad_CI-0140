using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class ProvinceMap : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");

            builder.HasKey("Name");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
