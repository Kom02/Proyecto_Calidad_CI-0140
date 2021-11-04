using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class BannedAcountMap : IEntityTypeConfiguration<BannedAcount>
    {
        public void Configure(EntityTypeBuilder<BannedAcount> builder)
        {
            builder.ToTable("Banned_Account");

            builder.HasKey(b => b.UserEmail);

            builder.Property(b => b.UserEmail)
                 .HasMaxLength(100)
                .HasColumnName("UserEmail");

            builder.Property(b => b.BeginDate)
                .HasColumnName("BeginDate");

            builder.Property(b => b.FinishDate)
                .HasColumnName("FinishDate");

            builder.Property(b => b.Type)
                .HasColumnName("Type");

        }
    }
}
