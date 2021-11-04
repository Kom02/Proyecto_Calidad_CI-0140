using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.Chats.TheChat.Repositories
{
    internal class ChatRepository : IChatRepository
    {

        private readonly ChatDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public ChatRepository(ChatDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<Chat>> GetAllAsync()
        {
            return await _dbContext.Chat
            .Select(p => new Chat(p.ID))
            .ToListAsync();
        }
        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await _dbContext.Chat
            .FirstOrDefaultAsync(p => p.ID == id);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(Chat chat)
        {
            _dbContext.Update(chat);
            await _dbContext.SaveEntitiesAsync();
        }
        public async Task<Chat?> AddChat()
        {
            Chat chat = new Chat();
            await _dbContext.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
    }
}