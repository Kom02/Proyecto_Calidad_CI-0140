using EmprendeUCR_WebApplication.Domain.Core.Helpers;
using EmprendeUCR_WebApplication.Domain.Core.ValueObjects;
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using EmprendeUCR_WebApplication.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;

/* This file is used to implement the map of the table knows as "ProductService" in the
 * context of the Orders.
 */
namespace EmprendeUCR_WebApplication.Infrastructure.OrderContext.EntityMappings
{
    public class ProductServiceMap : IEntityTypeConfiguration<ProductService>
    {

        /* Summary: Take the received builder and map with it the different
         *          attributes of the "ProductService" table, relating them to
         *          the "ProductService" entity.
         * Parameters: Receives the builder used to map.
         * Return: Nothing.
         * Exceptions: There aren't known exceptions.
        */
        public void Configure(EntityTypeBuilder<ProductService> builder)
        {
            builder.HasKey(e => new { e.CodeId, e.EntrepreneurEmail, e.CategoryId });

            builder.ToTable("Product_Service");

            builder.Property(e => e.CodeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Code_ID");

            builder.Property(e => e.EntrepreneurEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Entrepreneur_Email");

            builder.Property(e => e.CategoryId).HasColumnName("Category_ID");

            builder.Property(e => e.Availability).HasDefaultValueSql("((1))");


            builder.Ignore(e => e.ShoppingCartHas);

            builder.HasIndex(t => new { t.CodeId, t.EntrepreneurEmail, t.CategoryId })
                .IsUnique();

        }
    }
}
