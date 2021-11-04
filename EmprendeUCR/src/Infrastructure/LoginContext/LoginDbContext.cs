using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Infrastructure.Core.EntityMappings;

namespace EmprendeUCR.Infrastructure.LoginContext
{
    public partial class LoginDbContext : ApplicationDbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options, ILogger<LoginDbContext> logger)
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<User> User { get; set;}
        public virtual DbSet<Client> Client { get; set;}
        public virtual DbSet<Entrepreneur> Entrepreneur { get; set;}
        public virtual DbSet<Administrator> Administrator { get; set;}
        public virtual DbSet<Credentials> Credentials { get; set;}
        public virtual DbSet<EmailConfirmation> EmailConfirmation { get; set;}
        public virtual DbSet<ActiveAdministrators> ActiveAdministrators { get; set; }
        public virtual DbSet<BannedAcount> BannedAcount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new EntrepreneurMap());
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new CredentialsMap());
            modelBuilder.ApplyConfiguration(new EmailConfirmationMap());
            modelBuilder.ApplyConfiguration(new ActiveAdministratorsMap());
            modelBuilder.ApplyConfiguration(new BannedAcountMap());
        }
    }
}
