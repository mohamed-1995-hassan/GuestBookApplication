using GuestBookApplication.Data.Models;
using GuestBookApplication.Repositories.Context;
using GuestBookApplication.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Repositories.Repositories
{
    public class MessageRepository :IMessageRepository
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageRepository(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateMessage(UserMessage userMessage)
        {
            userMessage.UserId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            userMessage.AddedDate = DateTime.Now;
            _context.Add(userMessage);
            await _context.SaveChangesAsync();
        }
        public async Task EditMessage(UserMessage userMessage)
        {
                userMessage.ModifiedDate = DateTime.Now;
                _context.Update(userMessage);
                await _context.SaveChangesAsync();
         }

        public UserMessage GetMessageUser(int? id) 
        {
            return _context.UserMessages.Find(id);
        }

        public async Task<UserMessage> GetMessageWithUser(int? id)
        {
            return await _context.UserMessages.Include(ms=>ms.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteUser(UserMessage userMessage)
        {
            _context.UserMessages.Remove(userMessage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserMessage>> GetAllMessages()
        {
           return await _context.UserMessages.Include(mes => mes.User).ToListAsync();
        }

        public bool GetAnyMessage(int id)
        {
            return _context.UserMessages.Any(e => e.Id == id);
        }
    }
}

