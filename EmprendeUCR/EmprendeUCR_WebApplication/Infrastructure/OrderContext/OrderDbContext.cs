using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lab2.Infrastructure.Core;
using Microsoft.Extensions.Logging;
using System.Reflection;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
using EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings;
using System.Diagnostics;

/* This file is used to create the database context of the orders, and with it 
 * the map of all the tables and entities need it.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext
{
    public partial class OrderDbContext : ApplicationDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options, ILogger<OrderDbContext> logger)
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductService> ProductServices { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Organized> Organizeds { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<GenericStatus> GenericStatuses { get; set; }
        public virtual DbSet<PersonalizedStatus> PersonalizedStatuses { get; set; }
        public virtual DbSet<ProductHasStatus> ProductHasStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductServiceMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrganizedMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new GenericStatusMap());
            modelBuilder.ApplyConfiguration(new PersonalizedStatusMap());
            modelBuilder.ApplyConfiguration(new ProductHasStatusMap());
        }
    }
}
