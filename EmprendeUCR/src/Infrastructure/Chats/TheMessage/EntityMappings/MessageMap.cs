using EmprendeUCR.Domain.Core.Helpers;
using EmprendeUCR.Domain.Core.ValueObjects;
using EmprendeUCR.Domain.Chats.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmprendeUCR.Infrastructure.Chats.TheMessage.EntityMappings
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(p => new{ p.Chat_ID, p.Message_Date});

        }
    }
}