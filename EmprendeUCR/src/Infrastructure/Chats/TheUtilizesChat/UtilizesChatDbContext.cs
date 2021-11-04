using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Chats.TheUtilizesChat.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmprendeUCR.Infrastructure.Chats.TheUtilizesChat
{
    public class UtilizesChatDbContext : ApplicationDbContext
    {
        public UtilizesChatDbContext(DbContextOptions<UtilizesChatDbContext> options, ILogger<UtilizesChatDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<UtilizesChat> UtilizesChat { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UtilizesChatMap());
        }
    }
}
