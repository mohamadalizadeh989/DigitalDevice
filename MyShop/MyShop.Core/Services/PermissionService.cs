using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Services;
using MyShop.Core.ViewModels.Users.Roles;
using MyShop.DataEf.Contexts;
using MyShop.Domain.Entities.Permissions;
using MyShop.Domain.Entities.Users;

namespace MyShop.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly MyShopContext _context;

        public PermissionService(MyShopContext context)
        {
            _context = context;
        }

        #region Roles

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public async Task<int> AddRoleAsync(int roleId, string roleTitle)
        {
            await _context.Roles.AddAsync(new Role()
            {
                RoleId = roleId,
                RoleTitle = roleTitle,
                IsDelete = false
            });
            await _context.SaveChangesAsync();
            return roleId;
        }
        public async Task<int> AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var myTask = Task.Run(() => _context.Roles.ToList());
            List<Role> result = await myTask;
            return result;
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
             _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<int> DeleteRoleAsync(Role role)
        {
            role.IsDelete = true;
            await UpdateRoleAsync(role);
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }


        #endregion

        #region Permission

        public async Task<List<Permission>> GetAllPermissionAsync()
        {
            return await _context.Permission.ToListAsync();
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var per in permission)
            {
                 _context.RolePermission.Add(new RolePermission()
                {
                    PermissionId = per,
                    RoleId = roleId
                });
            }

            _context.SaveChanges();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _context.RolePermission
                .Where(r => r.RoleId == roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            _context.RolePermission.Where(p => p.RoleId == roleId)
                .ToList().ForEach(p => _context.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).UserId;
            List<int> UserRoles = _context.UserRoles
                .Where(r => r.UserId == userId)
                .Select(r => r.RoleId)
                .ToList();

            if (!UserRoles.Any())
                return false;

            List<int> RolePermission = _context.RolePermission
                .Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId).ToList();

            return RolePermission.Any(p => UserRoles.Contains(p));
        }

        #endregion
    }
}
    