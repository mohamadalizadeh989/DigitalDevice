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
                string fixedEmail = login.Email.Fixed();
                var user = await _accountService.GetUserByEmailAsync(fixedEmail);

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

            if (await _accountService.IsDuplicatedUserNameAsync(register.UserName))
            {
                ModelState.AddModelError(nameof(register.UserName), "نام کاربری وارد شده تکراری می باشد");
                return View(register);
            }


            if (await _accountService.IsDuplicatedEmailAsync(StringExtension.Fixed(register.Email)))
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
            ViewBag.IsActive = await _accountService.ActiveAccountAsync(id);
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


        #region Forgot Password

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVm forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }

            string fixedEmail = forgot.Email.Fixed();
            UserDetailVm user = await _accountService.GetUserByEmailAsync(fixedEmail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);
            }

            string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);
            ViewBag.IsSuccess = true;

            return View();
        }

        #endregion


        #region Reset Password
        [Route("account/resetPassword/{id?}")]
        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id
            });
        }

        [Route("account/resetPassword/{id?}")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
                return View(reset);

            UserDetailVm user = await _accountService.GetUserByActiveCodeVmAsync(reset.ActiveCode);

            if (user == null)
                return NotFound();

            string hashNewPassword = _securityService.HashPassword(reset.Password);
            user.Password = hashNewPassword;

            _accountService.UpdateUser(user);

            return RedirectToAction("Login");

        }
        #endregion

    }
}
