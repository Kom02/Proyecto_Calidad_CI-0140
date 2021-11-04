using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Chats.TheMessage.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmprendeUCR.Infrastructure.Chats.TheMessage
{
    public class MessageDbContext : ApplicationDbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options, ILogger<MessageDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<Message> Message { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MessageMap());
        }
    }
}