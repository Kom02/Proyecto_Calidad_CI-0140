using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.PaymentInfos.SinpeIban
{
    public class SinpeIbanPaymentInfoDbContext : ApplicationDbContext
    {
        public SinpeIbanPaymentInfoDbContext(DbContextOptions<SinpeIbanPaymentInfoDbContext> options, ILogger<SinpeIbanPaymentInfoDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<SinpeIbanPaymentInfo> SinpeIbanPaymentInfo { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SinpeIbanPaymentInfoMap());
        }
    }
}