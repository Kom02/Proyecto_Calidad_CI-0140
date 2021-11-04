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
using EmprendeUCR.Domain.Reports.Entities;
using EmprendeUCR.Infrastructure.Reports;

namespace EmprendeUCR.Infrastructure.ProfileContext
{
    public partial class ProfileDbContext : ApplicationDbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options, ILogger<ProfileDbContext> logger)
            : base(options, logger)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Entrepreneur> Entrepreneur { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Province> Province { get; set;}
        public virtual DbSet<Canton> Canton { get; set;}
        public virtual DbSet<District> District { get; set;}
        public virtual DbSet<EmailConfirmation> EmailConfirmation { get; set; }
        public virtual DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MembersMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new EntrepreneurMap());
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new LikesMap());
            modelBuilder.ApplyConfiguration(new PhonesMap());
            modelBuilder.ApplyConfiguration(new ProvinceMap());
            modelBuilder.ApplyConfiguration(new CantonMap());
            modelBuilder.ApplyConfiguration(new DistrictMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            //modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.ApplyConfiguration(new EmailConfirmationMap());
        }
    }
}
