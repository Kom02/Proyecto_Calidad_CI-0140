using EmprendeUCR.Domain.Categories.Entities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Categories.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmprendeUCR.Infrastructure.Categories
{
    public class CategoriesDbContext : ApplicationDbContext
    {
        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options, ILogger<CategoriesDbContext> logger)
            : base(options, logger)
        {
        }
        public DbSet<Category> Categories { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriesMap());
        }
    }
}