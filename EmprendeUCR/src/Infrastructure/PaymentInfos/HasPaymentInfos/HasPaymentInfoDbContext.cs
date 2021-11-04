using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.PaymentInfos.HasPaymentInfos
{
    public class HasPaymentInfoDbContext : ApplicationDbContext
    {
        public HasPaymentInfoDbContext(DbContextOptions<HasPaymentInfoDbContext> options, ILogger<HasPaymentInfoDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<HasPaymentInfo> HasPaymentInfo { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HasPaymentInfoMap());
        }
    }
}