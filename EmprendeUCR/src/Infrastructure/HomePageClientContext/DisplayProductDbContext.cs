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
    public partial class DisplayProductDbContext : ApplicationDbContext
    {
        public DisplayProductDbContext(DbContextOptions<DisplayProductDbContext> options, ILogger<DisplayProductDbContext> logger)
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}