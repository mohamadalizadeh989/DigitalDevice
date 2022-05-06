using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.ViewModels.Users.Roles;
using MyShop.Domain.Entities.Permissions;
using MyShop.Domain.Entities.Users;

namespace MyShop.Core.Services
{
    public interface IPermissionService
    {

        #region Roles

        List<Role> GetRoles();
        Task<int> AddRoleAsync(int roleId, string roleTitle);
        //int AddRole(int roleId, string roleTitle);
        Task<int> AddRoleAsync(Role role);
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<List<Role>> GetRolesAsync();
        Task<int> UpdateRoleAsync(Role role);
        Task<int> DeleteRoleAsync(Role role);
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditRolesUser(int userId, List<int> rolesId);


        #endregion

        #region Permission

        Task<List<Permission>> GetAllPermissionAsync();
        void AddPermissionsToRole(int roleId, List<int> permission);
        List<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId, List<int> permissions);
        bool CheckPermission(int permissionId, string userName);

        #endregion
    }
}
