using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Infrastructure.Core.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EmprendeUCR.Infrastructure.PermissionContext
{
    public partial class PermissionDbContext : ApplicationDbContext
    {
        public PermissionDbContext(DbContextOptions<PermissionDbContext> options, ILogger<PermissionDbContext> logger)
        : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Is_Able_To> Is_Able_To { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Entrepreneur> Entrepreneur { get; set; }
        public virtual DbSet<EmailConfirmation> EmailConfirmation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new Is_Able_ToMap());
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new EntrepreneurMap());
            modelBuilder.ApplyConfiguration(new EmailConfirmationMap());
        }

    }
}
