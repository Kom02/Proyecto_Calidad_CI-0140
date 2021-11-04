using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using System;

namespace EmprendeUCR.Application.Chats
{
    public interface IMessageService
    {

        public Task<Message?> GetMessageByIdAsync(int chatID, DateTimeOffset date);
        public Task<IEnumerable<Message>> GetMessagesAsync();
        public Task AddMessageAsync(Message message);
    }
}