using GuestBookApplication.Data.Models;
using GuestBookApplication.Data.ViewModels;
using GuestBookApplication.Repositories.IRepositories;
using GuestBookApplication.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Service.Services
{
   public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task RegisterUser(User user)
        {
            await _accountRepository.RegisterUser(user);
        }

        public User GetUserByEmailAndPassword(LoginViewModel loginViewModel)
        {
            return _accountRepository.GetUserByEmailAndPassword(loginViewModel);
        }
        public User GetUserByEmailOrPassword(User user)
        {
            return _accountRepository.GetUserByEmailOrPassword(user);
        }
    }
}
