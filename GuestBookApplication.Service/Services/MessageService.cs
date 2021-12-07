using GuestBookApplication.Data.Models;
using GuestBookApplication.Repositories.IRepositories;
using GuestBookApplication.Repositories.Repositories;
using GuestBookApplication.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task CreateMessage(UserMessage userMessage)
        {
            await _messageRepository.CreateMessage(userMessage);
        }

        public async Task DeleteUser(UserMessage userMessage)
        {
            await _messageRepository.DeleteUser(userMessage);
        }

        public async Task EditMessage(UserMessage userMessage)
        {
            await _messageRepository.EditMessage(userMessage);
        }

        public async Task<List<UserMessage>> GetAllMessages()
        {
            return await _messageRepository.GetAllMessages();
        }

        public bool GetAnyMessage(int id)
        {
            return _messageRepository.GetAnyMessage(id);
        }

        public UserMessage GetMessageUser(int? id)
        {
            return _messageRepository.GetMessageUser(id);
        }

        public Task<UserMessage> GetMessageWithUser(int? id)
        {
            return _messageRepository.GetMessageWithUser(id);
        }
    }
}
