using GuestBookApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Repositories.IRepositories
{
    public interface IMessageRepository
    {
        Task CreateMessage(UserMessage userMessage);
        Task EditMessage(UserMessage userMessage);
        UserMessage GetMessageUser(int? id);
        Task<UserMessage> GetMessageWithUser(int? id);
        Task DeleteUser(UserMessage userMessage);
        Task<List<UserMessage>> GetAllMessages();
        bool GetAnyMessage(int id);
    }
}
