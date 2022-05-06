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
    [PermissionChecker(5)]
    public class DeleteUserController : UsersController
    {
        private readonly IAccountService _accountService;

        public DeleteUserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public InformationUserViewModel InformationUserViewModel { get; set; }

        [Route("/Admin/Users/DeleteUser/{id?}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["UserId"] = id;
            InformationUserViewModel = await _accountService.GetUserInformationAsync(id);
            return View(InformationUserViewModel);
        }

        [Route("/Admin/Users/DeleteUser/{id?}")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> IndexAsync(int UserId)
        {
            await _accountService.DeleteUserAsync(UserId);
            return Redirect("/Admin/Users");
        }
    }
}
