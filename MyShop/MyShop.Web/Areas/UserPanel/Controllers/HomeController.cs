using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyShop.Core.Services;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelController
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            if (User.Identity != null)
            {
                var user = _accountService.GetUserInformation(User.Identity.Name);
                return View(user);
            }

            return View();
        }

        [Route("UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfileAsync()
        {
            if (User.Identity != null)
            {
                var user = await _accountService.GetDataForEditProfileUserAsync(User.Identity.Name);
                return View(user);
            }
            return View();
        }

        [Route("UserPanel/EditProfile")]
        [HttpPost]
        public async Task<IActionResult> EditProfileAsync(EditProfileViewModel profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

            await _accountService.EditProfileAsync(User.Identity.Name, profile);

            //Log Out User
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/auth/Login?EditProfile=true");
        }


        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Route("UserPanel/ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            string currentUserName = User.Identity.Name;
            
            if (!ModelState.IsValid)
                return View(change);

            if (!_accountService.CompareOldPassword(change.OldPassword, currentUserName))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد");
                return View(change);
            }   

            _accountService.ChangeUserPassword(currentUserName,change.Password);
            ViewBag.IsSuccess = true;

            //Log Out User
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/auth/Login?EditProfile=true");
        }
    }
}
