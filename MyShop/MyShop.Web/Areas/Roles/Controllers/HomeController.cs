using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;
using MyShop.Domain.Entities.Users;

namespace MyShop.Web.Areas.Roles.Controllers
{
    [PermissionChecker(6)]
    public class HomeController : RolesController
    {
        private IPermissionService _permissionService;

        public HomeController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> RolesList { get; set; }

        [Route("/Admin/Roles")]
        public async Task<IActionResult> Index()
        {
            RolesList = await _permissionService.GetRolesAsync();
            ViewData["Roles"] = RolesList;
            return View(RolesList);
        }
    }
}
