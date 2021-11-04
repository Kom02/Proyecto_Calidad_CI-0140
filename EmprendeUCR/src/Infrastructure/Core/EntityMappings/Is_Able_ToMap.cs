using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class Is_Able_ToMap : IEntityTypeConfiguration<Is_Able_To>
    {
        public void Configure(EntityTypeBuilder<Is_Able_To> builder)
        {
            builder.ToTable("Is_Able_To");

            builder.HasKey(e => new { e.Email, e.Role_Id, e.Permission_Id } );

            builder.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Email");

            builder.Property(e => e.Role_Id)
                    .IsRequired()
                    .HasColumnName("Role_Id");

            builder.Property(e => e.Permission_Id)
                    .IsRequired()
                    .HasColumnName("Permission_Id");
        }
    }
}
