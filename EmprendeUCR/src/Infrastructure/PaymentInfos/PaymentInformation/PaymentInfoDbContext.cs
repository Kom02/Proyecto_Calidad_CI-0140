using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.PaymentInfos.PaymentInformation
{
    public class PaymentInfoDbContext : ApplicationDbContext
    {
        public PaymentInfoDbContext(DbContextOptions<PaymentInfoDbContext> options, ILogger<PaymentInfoDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<PaymentInfo> PaymentInfo { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentInfoMap());
        }
    }
}