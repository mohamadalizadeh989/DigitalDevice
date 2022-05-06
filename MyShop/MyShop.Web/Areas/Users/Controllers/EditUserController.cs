using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Areas.Users.Controllers
{
    [PermissionChecker(4)]
    public class EditUserController : UsersController
    {
        private readonly IAccountService _accountService;
        private readonly IPermissionService _permissionService;

        public EditUserController(IAccountService accountService, IPermissionService permissionService)
        {
            _accountService = accountService;
            _permissionService = permissionService;
        }


        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }


        [Route("/Admin/Users/EditUser/{id?}")]
        public async Task<IActionResult> IndexAsync(int id)
        {
            EditUserViewModel = await _accountService.GetUserForShowInEditModeAsync(id);
            ViewData["Roles"] = await _permissionService.GetRolesAsync();
            return View(EditUserViewModel);
        }


        [Route("/Admin/Users/EditUser/{id?}")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexAsync(int id, List<int> selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            //ViewData["Roles"] = await _permissionService.GetRolesAsync();
            await _accountService.EditUserFromAdminAsync(EditUserViewModel);

            //Edit Roles
            _permissionService.EditRolesUser(EditUserViewModel.UserId, selectedRoles);
            return Redirect("/Admin/Users");
        }
    }
}
