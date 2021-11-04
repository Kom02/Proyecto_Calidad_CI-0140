using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class AdministratorMap : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrator")
                .HasKey(admin => admin.User_Email);

            builder.Property(admin => admin.User_Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("User_Email");
        }
    }
}
