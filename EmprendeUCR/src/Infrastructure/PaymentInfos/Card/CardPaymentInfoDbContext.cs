using EmprendeUCR.Domain.PaymentInfos.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.PaymentInfos.Card.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.PaymentInfos.Card
{
    public class CardPaymentInfoDbContext : ApplicationDbContext
    {
        public CardPaymentInfoDbContext(DbContextOptions<CardPaymentInfoDbContext> options, ILogger<CardPaymentInfoDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<CardPaymentInfo> CardPaymentInfo { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CardPaymentInfoMap());
        }
    }
}