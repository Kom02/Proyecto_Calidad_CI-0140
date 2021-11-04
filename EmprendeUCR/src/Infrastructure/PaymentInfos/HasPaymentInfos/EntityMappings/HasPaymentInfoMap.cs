using EmprendeUCR.Domain.PaymentInfos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos.EntityMappings
{
    public class HasPaymentInfoMap : IEntityTypeConfiguration<HasPaymentInfo>
    {
        public void Configure(EntityTypeBuilder<HasPaymentInfo> builder)
        {
            builder.ToTable("Has_Payment_Info");

            builder.HasKey(p => new { p.Entrepreneur_Email, p.Payment_Info_ID });

        }
    }
}