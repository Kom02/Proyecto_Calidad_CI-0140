using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class LikesMap : IEntityTypeConfiguration<Likes>
    {
        public void Configure(EntityTypeBuilder<Likes> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(e => new { e.Members_Email, e.Category_Id } );

            builder.Property(e => e.Members_Email)
                .HasColumnName("Members_Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Category_Id)
                .HasColumnName("Category_Id")
                .IsRequired();
        }
    }
}
