using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;

namespace EmprendeUCR_WebApplication.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Entrepreneur> Entrepreneur { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product_Service> Product_Service { get; set; }

        //protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema()
        //}

    }
}

