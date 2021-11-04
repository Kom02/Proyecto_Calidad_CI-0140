using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;

namespace EmprendeUCR.Application.Chats
{
    public interface IUtilizesChatService
    {
        public Task<UtilizesChat?> GetUtilizesChatByIdAsync(int chatID, string userEmail);
        public Task<IEnumerable<UtilizesChat>> GetUtilizesChatsAsync();
        public Task AddUtilizesChatAsync(UtilizesChat utilizesChat);
    }
}
