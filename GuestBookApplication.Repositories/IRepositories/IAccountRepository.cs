using GuestBookApplication.Data.Models;
using GuestBookApplication.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookApplication.Repositories.IRepositories
{
    public interface IAccountRepository
    {
        Task RegisterUser(User user);
        User GetUserByEmailAndPassword(LoginViewModel loginViewModel);
        User GetUserByEmailOrPassword(User user);
    }
}
