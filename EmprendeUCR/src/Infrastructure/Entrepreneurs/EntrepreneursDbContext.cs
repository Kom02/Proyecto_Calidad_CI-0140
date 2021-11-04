using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Entrepreneurs.EntityMappings;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services.Products;
using EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services;

namespace EmprendeUCR.Infrastructure.Entrepreneurs
{
    public class EntrepreneursDbContext : ApplicationDbContext
    {

        public EntrepreneursDbContext(DbContextOptions options, ILogger<EntrepreneursDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Product_Service> ProductServices { get; set; } = null!;
        public DbSet<ProductPhotos> ProductPhotos { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductServiceMap());
            modelBuilder.ApplyConfiguration(new ProductPhotoMap());
        }
    }
}