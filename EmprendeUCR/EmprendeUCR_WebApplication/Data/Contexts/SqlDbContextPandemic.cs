using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;

namespace EmprendeUCR_WebApplication.Data.Contexts
{
    public class SqlDbContextPandemic : DbContext
    {
       public SqlDbContextPandemic(DbContextOptions<SqlDbContextPandemic> options)
           : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Canton> Canton { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Entrepreneur> Entrepreneur { get; set; }
        public DbSet<Product_Service> Product_Service { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Email_Confirmation> Email_Confirmation { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Shopping_Cart_Has> Shopping_Cart_Has { get; set; }
        public DbSet<Is_Able_To> Is_Able_To { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tells entity framework this entity has a composite key.
            modelBuilder.Entity<Is_Offer>()
                .HasKey(o => new { o.Offer_ID, o.Code_ID, o.User_Email, o.Category_ID });

            modelBuilder.Entity<Is_Able_To>()
                .HasKey(o => new { o.Email, o.Permission_Id, o.Role_Id});

            var likes = modelBuilder.Entity<Likes>();
            likes.HasKey(b => new { b.Members_Email, b.Category_Id });

            var shoppingCartHas = modelBuilder.Entity<Shopping_Cart_Has>();
            shoppingCartHas.HasKey(c => new { c.Email, c.Code_ID, c.Entrepreneur_Email, c.Category_ID });
        }
    }
}