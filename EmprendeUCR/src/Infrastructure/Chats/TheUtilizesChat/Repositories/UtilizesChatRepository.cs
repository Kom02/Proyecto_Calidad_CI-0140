using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;
using EmprendeUCR.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR.Infrastructure.Chats.TheUtilizesChat.Repositories
{
    internal class UtilizesChatRepository : IUtilizesChatRepository
    {
        private readonly UtilizesChatDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public UtilizesChatRepository(UtilizesChatDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        public async Task<IEnumerable<UtilizesChat>> GetAllAsync()
        {
            return await _dbContext.UtilizesChat
            .Select(p => new UtilizesChat(p.Chat_ID, p.User_Email))
            .ToListAsync();
        }
        public async Task<UtilizesChat?> GetByIdAsync(int chatID, string userEmail)
        {
            return await _dbContext.UtilizesChat
            .FirstOrDefaultAsync(p => p.Chat_ID == chatID && p.User_Email == userEmail);
        }
        /// <summary>
        /// Saves aggregate and commits changes
        /// </summary>
        public async Task SaveAsync(UtilizesChat utilizesChat)
        {
            _dbContext.Update(utilizesChat);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task AddUtilizesChat(UtilizesChat utilizesChat)
        {
            await _dbContext.AddAsync(utilizesChat);
            await _dbContext.SaveChangesAsync();
        }
    }
}