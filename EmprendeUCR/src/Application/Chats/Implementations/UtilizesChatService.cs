using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;
//agregar using de usuario

namespace EmprendeUCR.Application.Chats.Implementations
{
    internal class UtilizesChatService : IUtilizesChatService
    {
        private readonly IUtilizesChatRepository _utilizesChatRepository;
        public UtilizesChatService(IUtilizesChatRepository utilizesChatRepository)
        {
            _utilizesChatRepository = utilizesChatRepository;
        }
        public async Task AddUtilizesChatAsync(UtilizesChat utilizesChat)
        {
            await _utilizesChatRepository.AddUtilizesChat(utilizesChat);
        }
        public async Task<UtilizesChat?> GetUtilizesChatByIdAsync(int chatID, string userEmail)
        {
            return await _utilizesChatRepository.GetByIdAsync(chatID, userEmail);
        }
        public async Task<IEnumerable<UtilizesChat>> GetUtilizesChatsAsync()
        {
            return await _utilizesChatRepository.GetAllAsync();
        }
    }
}