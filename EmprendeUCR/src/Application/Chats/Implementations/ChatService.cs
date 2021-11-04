using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;

namespace EmprendeUCR.Application.Chats.Implementations
{
    internal class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        public async Task<Chat?> GetChatByIdAsync(int id)
        {
            return await _chatRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Chat>> GetChatsAsync()
        {
            return await _chatRepository.GetAllAsync();
        }
        public async Task<Chat?> AddChatAsync()
        {
            return await _chatRepository.AddChat();
        }
    }
}