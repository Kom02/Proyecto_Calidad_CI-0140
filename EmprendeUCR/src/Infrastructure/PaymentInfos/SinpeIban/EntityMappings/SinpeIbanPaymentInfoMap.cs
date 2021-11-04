using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban.EntityMappings
{
    public class SinpeIbanPaymentInfoMap : IEntityTypeConfiguration<SinpeIbanPaymentInfo>
    {
        public void Configure(EntityTypeBuilder<SinpeIbanPaymentInfo> builder)
        {
            builder.ToTable("SINPE_IBAN_PI");

            builder.HasKey(p => p.Account_Number);

        }
    }
}