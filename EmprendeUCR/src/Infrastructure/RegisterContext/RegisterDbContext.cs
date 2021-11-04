using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using EmprendeUCR.Infrastructure.Core;
using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Infrastructure.Core.EntityMappings;
using EmprendeUCR.Domain.RegisterContext.Entities;

namespace EmprendeUCR.Infrastructure.RegisterContext
{
    public partial class RegisterDbContext : ApplicationDbContext
    {
        public RegisterDbContext(DbContextOptions<RegisterDbContext> options, ILogger<RegisterDbContext> logger)
           : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set;}
        public virtual DbSet<Client> Client { get; set;}
        public virtual DbSet<Entrepreneur> Entrepreneur { get; set;}
        public virtual DbSet<User> User { get; set;}
        public virtual DbSet<EmailConfirmation> EmailConfirmation { get; set;}
        public virtual DbSet<Canton> Canton { get; set;}
        public virtual DbSet<Province> Province { get; set;}
        public virtual DbSet<District> District { get; set;}
        public virtual DbSet<Mail> Mail { get; set;}
        public virtual DbSet<Credentials> Credentials { get; set;}
        public virtual DbSet<Members> Members { get; set;}
        public virtual DbSet<Likes> Likes { get; set;}
        public virtual DbSet<Phones> Phones { get; set;}
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<ActiveAdministrators> ActiveAdministrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Mail>();
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new EntrepreneurMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MembersMap());
            modelBuilder.ApplyConfiguration(new ProvinceMap());
            modelBuilder.ApplyConfiguration(new CantonMap());
            modelBuilder.ApplyConfiguration(new DistrictMap());
            modelBuilder.ApplyConfiguration(new PhonesMap());
            modelBuilder.ApplyConfiguration(new LikesMap());
            modelBuilder.ApplyConfiguration(new CredentialsMap());
            modelBuilder.ApplyConfiguration(new EmailConfirmationMap());
            //modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ShoppingCartMap());
            modelBuilder.ApplyConfiguration(new ActiveAdministratorsMap());
        }
    }
}
