using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Domain.NotificationContext;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Lab2.Infrastructure.Core;
using EmprendeUCR_WebApplication.Infrastructure.NotificationContext.EntitityMappings;
using EmprendeUCR_WebApplication.Data.Entities;


/* This file is used to create the database context of the Notifications, and with it 
 * the map of all the tables and entities need it.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.NotificationContext
{
    public partial class NotificationDbContext : ApplicationDbContext
    {

        public NotificationDbContext(DbContextOptions<NotificationDbContext> options, ILogger<NotificationDbContext> logger)
            : base(options,logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<OrderNotificationClient> OrderNotificationClients { get; set; }
        public virtual DbSet<OrderNotificationEntrepeneur> OrderNotificationEntrepeneurs { get; set; }
        public DbSet<Shopping_Cart_Has> Shopping_Cart_Has { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderNotificationClientMap());
            modelBuilder.ApplyConfiguration(new OrderNotificationEntrepeneurMap());
            var shoppingCartHas = modelBuilder.Entity<Shopping_Cart_Has>();
            shoppingCartHas.HasKey(c => new { c.Email, c.Code_ID, c.Entrepreneur_Email, c.Category_ID });
        }

    }
}
