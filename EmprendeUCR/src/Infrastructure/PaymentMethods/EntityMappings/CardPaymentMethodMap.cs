using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentMethods.EntityMappings
{
    public class CardPaymentMethodMap : IEntityTypeConfiguration<CardPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<CardPaymentMethod> builder)
        {
            builder.ToTable("CARD_PM");

            builder.HasKey(p => p.Name);

            builder.Property(p => p.Status);

        }
    }
}