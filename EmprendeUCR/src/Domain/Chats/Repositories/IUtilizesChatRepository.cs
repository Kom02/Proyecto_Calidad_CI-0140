using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using System;

namespace EmprendeUCR.Domain.Chats.Repositories
{
    public interface IUtilizesChatRepository
    {
        Task SaveAsync(UtilizesChat utilizesChat);
        Task<IEnumerable<UtilizesChat>> GetAllAsync();
        Task<UtilizesChat?> GetByIdAsync(int chatID, string userEmail);
        Task AddUtilizesChat(UtilizesChat utilizesChat);
    }
}
