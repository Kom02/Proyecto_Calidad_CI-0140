using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class MembersMap : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.ToTable("Members");

            builder.HasKey("User_Email");

            builder.Property(e => e.User_Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("User_Email");

            builder.Property(e => e.Score)
                .HasColumnName("Score");

            builder.Property(e => e.Lat)
                .HasColumnName("Lat");

            builder.Property(e => e.Long)
                .HasColumnName("Long");

            builder.Property(e => e.Direction)
                .HasMaxLength(250)
                .HasColumnName("Direction");
        }
    }
}
