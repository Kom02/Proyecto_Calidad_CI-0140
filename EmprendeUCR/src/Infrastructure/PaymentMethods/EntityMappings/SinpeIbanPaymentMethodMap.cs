using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentMethods.EntityMappings
{
    public class SinpeIbanPaymentMethodMap : IEntityTypeConfiguration<SinpeIbanPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<SinpeIbanPaymentMethod> builder)
        {
            builder.ToTable("SINPE_IBAN_PM");

            builder.HasKey(p => p.Name);

            builder.Property(p => p.Status);

        }
    }
}