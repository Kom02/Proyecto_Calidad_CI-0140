using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;
using EmprendeUCR.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using System;


namespace EmprendeUCR.Infrastructure.Chats.TheMessage.Repositories
{
    internal class MessageRepository : IMessageRepository
    {
        private readonly MessageDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public MessageRepository(MessageDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            return await _dbContext.Message
            .Select(p => new Message(p.Chat_ID, p.Writer_User_Email, p.Reader_User_Email, p.Content))
            .ToListAsync();
        }
        public async Task<Message?> GetByIdAsync(int chatID, DateTimeOffset date)
        {
            return await _dbContext.Message
            .FirstOrDefaultAsync(p => p.Chat_ID == chatID && p.Message_Date == date);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(Message message)
        {
            _dbContext.Update(message);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddMessage(Message message)
        {
            await _dbContext.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}