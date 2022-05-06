using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users.Roles;
using MyShop.Domain.Entities.Users;

namespace MyShop.Web.Areas.Roles.Controllers
{
    [PermissionChecker(7)]
    public class CreateRoleController : RolesController
    {
        private readonly IPermissionService _permissionService;

        public CreateRoleController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        //public CreateRoleViewModel CreateRoleViewModel { get; set; }
        public Role Role { get; set; }

        [Route("/Admin/Roles/CreateRole/{id?}")]
        public async Task<IActionResult> Index()
        {
            ViewData["Permissions"] = await _permissionService.GetAllPermissionAsync();
            return View();
        }

        [Route("/Admin/Roles/CreateRole/{id?}")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(CreateRoleViewModel create,List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return View(create);
            }

            ViewData["Permissions"] = await _permissionService.GetAllPermissionAsync();

            Role.IsDelete = false;
            int roleId = await _permissionService.AddRoleAsync(Role);
            //int roleId = await _permissionService.AddRoleAsync(create.RoleId, create.RoleTitle);

            _permissionService.AddPermissionsToRole(roleId, SelectedPermission);


            return Redirect("/Admin/Roles");
        }
    }
}
