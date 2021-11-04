using System.Collections.Generic;
using System.Threading.Tasks;
using EmprendeUCR.Domain.Chats.Entities;
using EmprendeUCR.Domain.Chats.Repositories;
using System;

namespace EmprendeUCR.Application.Chats.Implementations
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task AddMessageAsync(Message message)
        {
            await _messageRepository.AddMessage(message);
        }
        public async Task<Message?> GetMessageByIdAsync(int chatID, DateTimeOffset date)
        {
            return await _messageRepository.GetByIdAsync(chatID, date);
        }
        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _messageRepository.GetAllAsync();
        }
    }
}