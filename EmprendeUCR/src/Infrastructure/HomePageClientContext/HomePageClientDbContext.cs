using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Infrastructure.Core.EntityMappings;

namespace EmprendeUCR.Infrastructure.HomePageClientContext
{
    public partial class HomePageClientDbContext : ApplicationDbContext
    {
        public HomePageClientDbContext(DbContextOptions<HomePageClientDbContext> options, ILogger<HomePageClientDbContext> logger)
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<ProductPhotos> ProductPhotos { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<ShoppingCartHas> ShoppingCartHas { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<ProductService> ProductService { get; set; }

        public virtual DbSet<Is_Offer> Is_Offer { get; set; }

        public virtual DbSet<Service_Photos> Service_Photos { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductPhotosMap());
            //modelBuilder.Entity<Product>().ToTable("Product").HasKey("Code_ID");
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            //modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.ApplyConfiguration(new ShoppingCartMap());
            modelBuilder.ApplyConfiguration(new ShoppingCartHasMap());
            modelBuilder.ApplyConfiguration(new OfferMap());
            modelBuilder.ApplyConfiguration(new ProductServiceMap());
            modelBuilder.ApplyConfiguration(new Is_OfferMap());
            modelBuilder.ApplyConfiguration(new Service_PhotosMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}