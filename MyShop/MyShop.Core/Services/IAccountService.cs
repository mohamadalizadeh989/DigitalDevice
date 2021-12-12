using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.ViewModels.Users;
using MyShop.Domain.Entities.Users;

namespace MyShop.Core.Services
{
    public interface IAccountService
    {
        Task<int> AddUserAsync(User user);
        Task<bool> RegisterAsync(AccountRegisterVm register);
        Task<bool> LoginAsync(AccountLoginVm login);
        Task<bool> IsDuplicatedUserNameAsync(string userName);
        Task<bool> IsDuplicatedEmailAsync(string email);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<User> GetUserByActiveCodeAsync(string activeCode);
        Task<UserDetailVm> GetUserByActiveCodeVmAsync(string activeCode);
        User GetUserByUserName(string userName);
        UserDetailVm GetUserByUserNameVm(string userName);
        Task<UserDetailVm> GetUserByIdAsync(int userId);
        Task<bool> ActiveAccountAsync(string activeCode);
        void UpdateUser(UserDetailVm user);

        #region User Panel

        InformationUserViewModel GetUserInformationAsync(string username);
        Task<SideBarUserPanelViewModel> GetSideBarUserPanelData(string username);

        #endregion
    }
}
