using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Services;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Controllers
{
    [Route("auth")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginVm vm)
        {
            if (!await _accountService.CheckEmailAndPasswordAsync(vm))
                ModelState.AddModelError(nameof(vm.Password), "ایمیل یا کلمه عبور صحیح نمی باشد");

            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmailAsync(vm.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email,vm.Email),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = vm.IsRemember
                };
                await HttpContext.SignInAsync(principal, properties);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(vm);
        }


        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterVm vm)
        {
            if (await _accountService.IsDuplicatedEmail(vm.Email))
                ModelState.AddModelError(nameof(vm.Email), "ایمیل وارد شده تکراری می باشد");

            if (ModelState.IsValid)
            {
                await _accountService.RegisterAsync(vm);
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }

        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
