using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBookApplication.Data.Models;
using GuestBookApplication.Repositories.Context;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GuestBookApplication.Service.IServices;

namespace GuestBookApplication.Controllers
{
    [Authorize]
    public class UserMessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public UserMessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {            
            return View(await _messageService.GetAllMessages());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Message")] UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                await _messageService.CreateMessage(userMessage);
                return RedirectToAction(nameof(Index));
            }
            return View(userMessage);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var userMessage = _messageService.GetMessageUser(id);
            if (userMessage == null)
                return NotFound();
            return View(userMessage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Message,UserId,Id,AddedDate,ModifiedDate")] UserMessage userMessage)
        {
            if (id != userMessage.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (userMessage.Id == int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    {
                        await _messageService.EditMessage(userMessage);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Un Authorize User to Edit");
                        return View(userMessage);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserMessageExists(userMessage.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userMessage);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var userMessage = await _messageService.GetMessageWithUser(id);
            if (userMessage == null)
                return NotFound();
            return View(userMessage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userMessage = _messageService.GetMessageUser(id);
            if (id == int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                await _messageService.DeleteUser(userMessage);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Un Authorize User to Edit");
                return View(userMessage);
            }
        }
        private bool UserMessageExists(int id)
        {
            return _messageService.GetAnyMessage(id);
        }
    }
}
