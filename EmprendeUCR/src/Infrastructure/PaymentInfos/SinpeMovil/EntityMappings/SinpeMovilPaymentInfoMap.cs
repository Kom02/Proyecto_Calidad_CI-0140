using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentInfos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil.EntityMappings
{
    public class SinpeMovilPaymentInfoMap : IEntityTypeConfiguration<SinpeMovilPaymentInfo>
    {
        public void Configure(EntityTypeBuilder<SinpeMovilPaymentInfo> builder)
        {
            builder.ToTable("Sinpe_Movil_PI");

            builder.HasKey(p => p.Phone_Number);

        }
    }
}