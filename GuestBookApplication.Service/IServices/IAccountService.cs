using GuestBookApplication.Data.Models;
using GuestBookApplication.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Service.IServices
{
   public interface IAccountService
   {
        Task RegisterUser(User user);
        User GetUserByEmailAndPassword(LoginViewModel loginViewModel);
        User GetUserByEmailOrPassword(User user);
    }
}
