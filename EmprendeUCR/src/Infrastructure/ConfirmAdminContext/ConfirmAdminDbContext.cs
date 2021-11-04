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

namespace EmprendeUCR.Infrastructure.ConfirmAdminContext
{
    public partial class ConfirmAdminDbContext : ApplicationDbContext
    {
        public ConfirmAdminDbContext(DbContextOptions<ConfirmAdminDbContext> options, ILogger<ConfirmAdminDbContext> logger)
        : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<ActiveAdministrators> ActiveAdministrators { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Mail>();
            modelBuilder.ApplyConfiguration(new ActiveAdministratorsMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
