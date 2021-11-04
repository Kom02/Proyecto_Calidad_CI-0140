using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class Service_PhotosMap : IEntityTypeConfiguration<Service_Photos>
    {
        public void Configure(EntityTypeBuilder<Service_Photos> builder)
        {
            builder.ToTable("Service_Photos");
            builder.HasKey(b => new { b.Service_Photos_ID, b.Code_ID, b.Entrepreneur_Email, b.Category_ID });


            builder.Property(e => e.Service_Photos_ID)
                .HasColumnName("Service_Photos_ID")
                .IsRequired();

            builder.Property(e => e.Code_ID)
                .HasColumnName("Code_ID")
                .IsRequired();

            builder.Property(e => e.Photos)
               .HasColumnName("Photos");

            builder.Property(e => e.Entrepreneur_Email)
             .HasColumnName("Entrepreneur_Email")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(e => e.Category_ID)
               .HasColumnName("Category_ID")
               .IsRequired();
        }
    }
}
