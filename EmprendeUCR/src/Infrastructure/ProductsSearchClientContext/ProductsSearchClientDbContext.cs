using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Core.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.ProductsSearchClientContext
{
    public partial class ProductsSearchClientDbContext : ApplicationDbContext
    {
        public ProductsSearchClientDbContext(DbContextOptions<ProductsSearchClientDbContext> options, ILogger<ProductsSearchClientDbContext> logger)
            : base(options, logger)
        {
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<Category> Category  { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ProductPhotos> ProductPhotos { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ShoppingCartHas> ShoppingCartHas { get; set; }
        public virtual DbSet<ProductService> ProductService { get; set; }

        public virtual DbSet<Service_Photos> Service_Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new ProductPhotosMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ShoppingCartHasMap());
            modelBuilder.ApplyConfiguration(new ProductServiceMap());
            modelBuilder.ApplyConfiguration(new Service_PhotosMap());
        }
    }
}