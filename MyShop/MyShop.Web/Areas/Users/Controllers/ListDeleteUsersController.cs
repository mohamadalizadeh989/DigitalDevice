using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Core.Services;
using MyShop.Core.ViewModels.Users;

namespace MyShop.Web.Areas.Users.Controllers
{
    public class ListDeleteUsersController : UsersController
    {
        private readonly IAccountService _accountService;

        public ListDeleteUsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public InformationUserViewModel InformationUserViewModel { get; set; }

        [Route("/Admin/Users/ListDeleteUsers")]
        public IActionResult Index(string userName, int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            if (User.Identity != null)
                UserForAdminViewModel = _accountService.GetDeleteUsers(User.Identity.Name, pageId, filterEmail, filterUserName);

            return View(UserForAdminViewModel);
        }
    }
}
