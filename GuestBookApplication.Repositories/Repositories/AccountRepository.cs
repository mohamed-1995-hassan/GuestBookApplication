using GuestBookApplication.Data.Models;
using GuestBookApplication.Data.ViewModels;
using GuestBookApplication.Repositories.Context;
using GuestBookApplication.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace GuestBookApplication.Repositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }
        

        public async Task RegisterUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public User GetUserByEmailAndPassword(LoginViewModel loginViewModel)
        {
            return _context.Users.Where(user => user.Email == loginViewModel.Email &&user.Password == loginViewModel.Password)
                .FirstOrDefault();
        }

        public User GetUserByEmailOrPassword(User user)
        {
            return _context.Users.FirstOrDefault(user => user.Email == user.Email || user.Password == user.Password);
        }
    }
}
