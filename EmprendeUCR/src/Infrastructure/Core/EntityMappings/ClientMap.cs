using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmprendeUCR.Domain.Core.CoreEntities;

namespace EmprendeUCR.Infrastructure.Core.EntityMappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client")
                .HasKey(client => client.User_Email);

            builder.Property(client => client.User_Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("User_Email");
        }
    }
}
