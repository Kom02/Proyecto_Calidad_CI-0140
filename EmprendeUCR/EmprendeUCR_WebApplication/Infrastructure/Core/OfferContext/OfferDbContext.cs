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
using EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext.EntityMappings;
#nullable disable

/* This file is used to create the database context of the shopping cart, and 
 * with it the map of all the tables and entities need it.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.Core.OfferContext
{
    public partial class OfferDbContext : ApplicationDbContext
    {
        public OfferDbContext(DbContextOptions<OfferDbContext> options, ILogger<OfferDbContext> logger) 
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<IsOffer> IsOffers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IsOfferMap());
            modelBuilder.ApplyConfiguration(new OfferMap());
        }
    }
}
