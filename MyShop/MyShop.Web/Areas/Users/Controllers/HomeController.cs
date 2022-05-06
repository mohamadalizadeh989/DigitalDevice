using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Areas.Users.Controllers
{
    [PermissionChecker(2)]
    public class HomeController : UsersController
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }

        [Route("/Admin/Users")]
        public IActionResult Index(string userName, int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            if (User.Identity != null)
                UserForAdminViewModel = _accountService.GetUsers(User.Identity.Name, pageId, filterEmail, filterUserName);
            return View(UserForAdminViewModel);
        }
    }
}
