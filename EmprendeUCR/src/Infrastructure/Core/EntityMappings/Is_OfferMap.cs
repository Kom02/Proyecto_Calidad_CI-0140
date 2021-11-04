using EmprendeUCR.Domain.Core.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    class Is_OfferMap : IEntityTypeConfiguration<Is_Offer>
    {
        public void Configure(EntityTypeBuilder<Is_Offer> builder)
        {
            builder.ToTable("Is_Offer");

            builder.HasKey(b => new { b.Offer_ID, b.Code_ID, b.User_Email, b.Category_ID });

            builder.Property(e => e.Offer_ID)
                .IsRequired()
                .HasColumnName("Offer_ID");

            builder.Property(e => e.Code_ID)
                .IsRequired()
                .HasColumnName("Code_ID");

            builder.Property(e => e.User_Email)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("User_Email");

            builder.Property(e => e.Category_ID)
                .IsRequired()
                .HasColumnName("Category_ID");

            builder.Property(e => e.Amount)
                .HasColumnName("Amount");
        }
    }
}
