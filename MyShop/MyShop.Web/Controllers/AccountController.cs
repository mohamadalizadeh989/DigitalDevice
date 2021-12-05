using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Generator;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Controllers
{
    [Route("auth")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ISecurityService _securityService;

        public AccountController(IAccountService accountService, ISecurityService securityService)
        {
            _accountService = accountService;
            _securityService = securityService;
        }


        #region Login

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginVm login)
        {
            if (!await _accountService.LoginAsync(login))
                ModelState.AddModelError(nameof(login.Password), "ایمیل یا کلمه عبور صحیح نمی باشد");

            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmailAsync(login.Email);

                if (user.IsActive)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Email,login.Email),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.IsRemember
                    };
                    await HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;

                    //return RedirectToAction("Index", "Home", new { area = "Admin" });
                    return View();
                }

                ModelState.AddModelError(nameof(login.Password), "حساب کاربری شما فعال نمی باشد");
            }
            return View(login);
        }

        #endregion


        #region Register

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterVm register)
        {
            if (ModelState.IsValid)
            {
                await _accountService.RegisterAsync(register);
                return View("SuccessRegister", register);
            }

            if (await _accountService.IsDuplicatedUserName(register.UserName))
            {
                ModelState.AddModelError(nameof(register.UserName), "نام کاربری وارد شده تکراری می باشد");
                return View(register);
            }


            if (await _accountService.IsDuplicatedEmail(StringExtension.Fixed(register.Email)))
            {
                ModelState.AddModelError(nameof(register.Email), "ایمیل وارد شده تکراری می باشد");
                return View(register);
            }

            return View();

        }

        #endregion


        #region Active Account

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _accountService.ActiveAccount(id);
            return View();
        }

        #endregion


        #region Logout

        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}
