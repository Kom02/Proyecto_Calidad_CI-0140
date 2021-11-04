using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class EmailConfirmationMap : IEntityTypeConfiguration<EmailConfirmation>
    {
        public void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            builder.ToTable("Email_Confirmation");

            builder.HasKey(c => c.Email);

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(e => e.Hash_Code)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnName("Hash_Code");

            builder.Property(e => e.Expiration_Date)
                .IsRequired()
                .HasColumnName("Expiration_Date");

            builder.Property(e => e.Creation_Date)
                .IsRequired()
                .HasColumnName("Creation_Date");
        }
    }
}
