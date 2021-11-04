using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class CredentialsMap : IEntityTypeConfiguration<Credentials>
    {
        public void Configure(EntityTypeBuilder<Credentials> builder)
        {
            builder.ToTable("Credentials");

            builder.HasKey(c => c.User_Email);

            builder.Property(e => e.User_Email)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("User_Email");

            builder.Property(e => e.Password)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
