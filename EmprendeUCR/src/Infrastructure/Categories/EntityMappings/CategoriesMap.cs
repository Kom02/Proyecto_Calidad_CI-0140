using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Categories.EntityMappings
{
    class CategoriesMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);
           
            builder.Property(c => c.Title);
        }
    }
}
