using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;
using MyShop.Web.Areas.Users.Controllers;

namespace MyShop.Web.Areas.Users.Controllers
{
    [PermissionChecker(3)]
    public class CreateUserController : UsersController
    {
        private readonly IAccountService _accountService;
        private readonly IPermissionService _permissionService;

        public CreateUserController(IAccountService accountService, IPermissionService permissionService)
        {
            _accountService = accountService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; } 


        [Route("/Admin/Users/CreateUser")]
        public async Task<IActionResult> Index()
        {
            ViewData["Roles"] = await _permissionService.GetRolesAsync();
            //ViewBag.Password = await _accountService.IsDuplicatedPasswordAsync(CreateUserViewModel.Password);
            return View();
        }

        [Route("/Admin/Users/CreateUser")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexAsync(List<int> selectedRole, CreateUserViewModel create)
        {
            //ViewBag.Password = await _accountService.AddUserFromAdminAsync(CreateUserViewModel);
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(create.Password))
                {
                    ModelState.AddModelError(nameof(create.Password), "لطفا کلمه عبور را وارد کنید");
                    return View(create);
                }

                if (string.IsNullOrWhiteSpace(create.UserName))
                {
                    ModelState.AddModelError(nameof(create.Password), "لطفا نام کاربری را وارد کنید");
                    return View(create);
                }

                if (string.IsNullOrWhiteSpace(create.Email))
                {
                    ModelState.AddModelError(nameof(create.Password), "لطفا ایمیل را وارد کنید");
                    return View(create);
                }

                if (!await _accountService.IsDuplicatedUserNameAsync(create.UserName) || await _accountService.IsDuplicatedEmailAsync(create.Email.Fixed()))
                {
                    ModelState.AddModelError(nameof(create.UserName), "نام کاربری یا ایمیل وارد شده تکراری می باشد");
                    return View(create);
                }
            }

            ViewData["Roles"] = await _permissionService.GetRolesAsync();

            int userId = await _accountService.AddUserFromAdminAsync(create);

            //Add Roles
            _permissionService.AddRolesToUser(selectedRole, userId);

            //return Redirect("/Admin/Users");
            return Redirect("/Admin/Users");
        }
    }
}
