using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class EntrepreneurMap : IEntityTypeConfiguration<Entrepreneur>
    {
        public void Configure(EntityTypeBuilder<Entrepreneur> builder)
        {
            builder.ToTable("Entrepreneur")
                .HasKey(entre => entre.User_Email);

            builder.Property(entre => entre.User_Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("User_Email");
        }
    }
}
