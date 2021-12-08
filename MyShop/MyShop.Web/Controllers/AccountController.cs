using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Generator;
using MyShop.Core.Senders;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Convertors;
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
        private readonly IViewRenderService _viewRender;

        public AccountController(IAccountService accountService, ISecurityService securityService, IViewRenderService viewRender)
        {
            _accountService = accountService;
            _securityService = securityService;
            _viewRender = viewRender;
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
                        new Claim(ClaimTypes.Name,user.UserName),
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
            if (!ModelState.IsValid)
            {
                return View(register);
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

            await _accountService.RegisterAsync(register);

            #region Send Activation Email


            var user = await _accountService.GetUserByEmailAsync(register.Email);
            string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);

            #endregion

            return View("SuccessRegister", register);

        }

        #endregion


        #region Active Account

        [Route("account/{id?}")]
        public async Task<IActionResult> ActiveAccount(string id)
        {
            ViewBag.IsActive = await _accountService.ActiveAccount(id);
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
