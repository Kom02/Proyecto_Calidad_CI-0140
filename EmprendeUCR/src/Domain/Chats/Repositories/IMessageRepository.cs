using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using System;

namespace EmprendeUCR.Domain.Chats.Repositories
{
    public interface IMessageRepository
    {
        Task SaveAsync(Message message);
        Task<IEnumerable<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(int chatID, DateTimeOffset date);
        Task AddMessage(Message message);
    }
}
