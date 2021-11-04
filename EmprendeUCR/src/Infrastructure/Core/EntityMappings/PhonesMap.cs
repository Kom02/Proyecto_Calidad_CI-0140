using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class PhonesMap : IEntityTypeConfiguration<Phones>
    {
        public void Configure(EntityTypeBuilder<Phones> builder) {

            builder.ToTable ( "Phones" );

            builder.HasKey("User_Email");
            builder.Property(e => e.User_Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("User_Email");


            builder.Property(e => e.Phone_Number)
                .IsRequired()
                .HasMaxLength(8)
                .HasColumnName("Phone_Number");
        }
    }
}
