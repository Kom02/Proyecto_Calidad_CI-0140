using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using Lab2.Infrastructure.Core;
using Microsoft.Extensions.Logging;
using System.Reflection;
using EmprendeUCR_WebApplication.Domain.ShoppingCartContext.Entities;
using EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext.EntityMappings;
using System.Diagnostics;
using EmprendeUCR_WebApplication.Domain.OrderContext.Entities;
#nullable disable

/* This file is used to create the database context of the shopping cart, and 
 * with it the map of all the tables and entities need it.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.ShoppingCartContext
{
    public partial class ShoppingCartDbContext2 : ApplicationDbContext
    {
        public ShoppingCartDbContext2(DbContextOptions<ShoppingCartDbContext2> options, ILogger<ShoppingCartDbContext2> logger) 
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
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShopLine> ShopLines { get; set; }
        public virtual DbSet<Product_Photos> Product_Photos { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Organized> Organizeds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            // Entities mapping from core entities
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductServiceMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new Product_PhotosMap());
            // Entities mapping from ShoppingCart context
            modelBuilder.ApplyConfiguration(new ShoppingCartMap());
            modelBuilder.ApplyConfiguration(new ProductLineMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrganizedMap());
        }
    }
}
