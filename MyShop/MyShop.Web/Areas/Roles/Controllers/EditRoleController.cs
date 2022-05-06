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
    [PermissionChecker(8)]
    public class EditRoleController : RolesController
    {
        private readonly IPermissionService _permissionService;

        public EditRoleController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        //public EditRoleViewModel EditRoleViewModel { get; set; }

        [Route("/Admin/Roles/EditRole/{id?}")]
        public async Task<IActionResult> Index(int id)
        {
            Role = await _permissionService.GetRoleByIdAsync(id);
            ViewData["Permissions"] = await _permissionService.GetAllPermissionAsync();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);
            //ViewData["Roles"] =  await _permissionService.GetRoleByIdAsync(id);
            return View(Role);
        }

        [Route("/Admin/Roles/EditRole/{id?}")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(List<int> SelectedPermission,int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewData["Permissions"] = await _permissionService.GetAllPermissionAsync();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);
            await _permissionService.UpdateRoleAsync(Role);
            _permissionService.UpdatePermissionsRole(Role.RoleId, SelectedPermission);

            return Redirect("/Admin/Roles");
        }
    }
} 
