using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;

namespace EmprendeUCR.Domain.Chats.Repositories
{
    public interface IChatRepository
    {
        Task SaveAsync(Chat chat);
        Task<IEnumerable<Chat>> GetAllAsync();
        Task<Chat?> GetByIdAsync(int id);
        Task<Chat?> AddChat();
    }
}