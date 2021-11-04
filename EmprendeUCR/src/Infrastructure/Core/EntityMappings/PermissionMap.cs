using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

            builder.HasKey(e => new { e.Id, e.Role_Id } );

            builder.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("Id");

            builder.Property(e => e.Role_Id)
                    .IsRequired()
                    .HasColumnName("Role_Id");

            builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Description");
        }
    }
}
