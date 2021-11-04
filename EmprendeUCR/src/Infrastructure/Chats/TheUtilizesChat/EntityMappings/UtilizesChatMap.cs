using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Chats.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Chats.TheUtilizesChat.EntityMappings
{
    public class UtilizesChatMap : IEntityTypeConfiguration<UtilizesChat>
    {
        public void Configure(EntityTypeBuilder<UtilizesChat> builder)
        {
            builder.ToTable("Utilizes_Chat");

            builder.HasKey(p => new { p.Chat_ID, p.User_Email });

        }
    }
}