using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Core.Utilities.Security;

namespace MyShop.Web.Areas.Admin.Controllers
{
    [PermissionChecker(1)]
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
