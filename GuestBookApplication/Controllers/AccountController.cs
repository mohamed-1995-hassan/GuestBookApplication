using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBookApplication.Data.Models;
using GuestBookApplication.Repositories.Context;
using GuestBookApplication.Data.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using GuestBookApplication.Service.IServices;

namespace GuestBookApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var CheckUser = _accountService.GetUserByEmailOrPassword(user);
                if(CheckUser!=null)
                {
                    ModelState.AddModelError("", "UserName or Password Are Duplicated");
                    return View(user);
                }
                await _accountService.RegisterUser(user);
                return RedirectToAction(nameof(Login));
            }
            return View(user);
        }
        public IActionResult Login(string ReturnUrl = "/")
        {
            LoginViewModel objLoginModel = new LoginViewModel();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.GetUserByEmailAndPassword(loginViewModel);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Credintial");
                    return View(loginViewModel);
                }
                else
                {
                    var claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = loginViewModel.RememberLogin
                    });
                    return LocalRedirect(loginViewModel.ReturnUrl);
                }
            }
            return View(loginViewModel);
        }
    }
}
