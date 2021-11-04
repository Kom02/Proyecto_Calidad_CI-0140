using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("Id");

            builder.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Type");
        }
    }
}
