using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey("Email");

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(15);

            builder.Property(e => e.F_Last_Name)
                .HasColumnName("F_Last_Name")
                .HasMaxLength(15);

            builder.Property(e => e.S_Last_Name)
                .HasColumnName("S_Last_Name")
                .HasMaxLength(15);

            builder.Property(e => e.Birth_Date)
                .HasColumnName("Birth_Date");

            builder.Property(e => e.Province_Name)
                .HasColumnName("Province_Name")
                .HasMaxLength(15);

            builder.Property(e => e.Canton_Name)
                .HasColumnName("Canton_Name")
                .HasMaxLength(15);

            builder.Property(e => e.District_Name)
                .HasColumnName("District_Name")
                .HasMaxLength(15);

            builder.Property(e => e.Email_Confirmation)
                .HasColumnName("Email_Confirmation");

            builder.Property(e => e.Photo)
                .HasColumnName("Photo");
        }
    }
}
