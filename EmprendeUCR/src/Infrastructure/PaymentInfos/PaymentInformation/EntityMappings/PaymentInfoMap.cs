using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation.EntityMappings
{
    public class PaymentInfoMap : IEntityTypeConfiguration<PaymentInfo>
    {
        public void Configure(EntityTypeBuilder<PaymentInfo> builder)
        {
            builder.ToTable("Payment_Info");

            builder.HasKey(p => p.ID);

        }
    }
}