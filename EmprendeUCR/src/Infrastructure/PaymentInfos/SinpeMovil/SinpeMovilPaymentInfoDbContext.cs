using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeMovil
{
    public class SinpeMovilPaymentInfoDbContext : ApplicationDbContext
    {
        public SinpeMovilPaymentInfoDbContext(DbContextOptions<SinpeMovilPaymentInfoDbContext> options, ILogger<SinpeMovilPaymentInfoDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<SinpeMovilPaymentInfo> SinpeMovilPaymentInfo { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SinpeMovilPaymentInfoMap());
        }
    }
}