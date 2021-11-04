using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;

namespace EmprendeUCR.Application.Chats
{
    public interface IChatService
    {
        public Task<Chat?> GetChatByIdAsync(int id);
        public Task<IEnumerable<Chat>> GetChatsAsync();
        public Task<Chat?> AddChatAsync();
    }
}