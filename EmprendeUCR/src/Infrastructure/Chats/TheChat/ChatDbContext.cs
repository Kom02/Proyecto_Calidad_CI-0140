using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Chats.TheChat.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmprendeUCR.Infrastructure.Chats.TheChat
{
    public class ChatDbContext : ApplicationDbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options, ILogger<ChatDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<Chat> Chat { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChatMap());
        }
    }
}