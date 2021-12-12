using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyShop.Core.Services;

namespace MyShop.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View(_accountService.GetUserInformationAsync(User.Identity.Name));
        }
    }
}
