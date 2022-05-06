using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Core.Services;
using MyShop.Core.Utilities.Security;
using MyShop.Domain.Entities.Users;

namespace MyShop.Web.Areas.Roles.Controllers
{
    [PermissionChecker(9)]
    public class DeleteRoleController : RolesController
    {
        private readonly IPermissionService _permissionService;

        public DeleteRoleController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        [Route("/Admin/Roles/DeleteRole/{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            Role = await _permissionService.GetRoleByIdAsync(id);
            return View(Role);
        }

        [Route("/Admin/Roles/DeleteRole/{id?}")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _permissionService.DeleteRoleAsync(Role);
            return Redirect("/Admin/Roles");
        }
    }
}
