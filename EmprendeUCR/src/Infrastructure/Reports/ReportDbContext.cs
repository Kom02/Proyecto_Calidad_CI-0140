using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Domain.Reports.Entities;
using EmprendeUCR.Infrastructure.Core.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace EmprendeUCR.Infrastructure.Reports
{
    public class ReportDbContext : ApplicationDbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options, ILogger<ReportDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<Report> Report { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReportMap());
        }
    }
}