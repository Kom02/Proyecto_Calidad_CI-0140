using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentInfos.Card.EntityMappings
{
    public class CardPaymentInfoMap : IEntityTypeConfiguration<CardPaymentInfo>
    {
        public void Configure(EntityTypeBuilder<CardPaymentInfo> builder)
        {
            builder.ToTable("CARD_PI");

            builder.HasKey(p => p.Account_Number);

        }
    }
}