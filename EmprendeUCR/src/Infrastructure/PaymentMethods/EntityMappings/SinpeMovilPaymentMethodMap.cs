using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.PaymentMethods.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmprendeUCR.Infrastructure.PaymentMethods.EntityMappings
{
    public class SinpeMovilPaymentMethodMap : IEntityTypeConfiguration<SinpeMovilPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<SinpeMovilPaymentMethod> builder)
        {
            builder.ToTable("SINPE_MOVIL_PM");

            builder.HasKey(p => p.Name);

            builder.Property(p => p.Status);

            builder.HasMany(p => p.SinpeMovilPaymentInfos)
                .WithOne(p => p.SinpeMovilPaymentMethod!);
        }
    }
}