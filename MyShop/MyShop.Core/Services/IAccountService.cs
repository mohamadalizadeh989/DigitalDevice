#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.ViewModels.Users;
using MyShop.Core.ViewModels.Wallet;
using MyShop.Domain.Entities.Users;
using MyShop.Domain.Entities.Wallet;

namespace MyShop.Core.Services
{
    public interface IAccountService
    {
        #region User

        Task<int> AddUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<bool> RegisterAsync(AccountRegisterVm register);
        Task<bool> LoginAsync(AccountLoginVm login);
        Task<bool> IsDuplicatedEmailAsync(string email);
        Task<bool> IsDuplicatedUserNameAsync(string userName);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<User> GetUserByActiveCodeAsync(string activeCode);
        Task<UserDetailVm> GetUserByActiveCodeVmAsync(string activeCode);
        User GetUserByUserName(string userName);
        UserDetailVm GetUserByUserNameVm(string userName);
        Task<User> GetUserByIdAsync(int userId);
        Task<UserDetailVm> GetUserVmByIdAsync(int userId);
        Task<bool> ActiveAccountAsync(string activeCode);
        void UpdateUser(UserDetailVm user);
        int GetUserIdByUserName(string userName);
        Task<bool> ExistAsync(int id);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> ReturnUserFromListDeleteUsersAsync(int userId);

        #endregion

        #region User Panel

        InformationUserViewModel GetUserInformation(string username);
        Task<InformationUserViewModel> GetUserInformationAsync(int userId);
        Task<SideBarUserPanelViewModel> GetSideBarUserPanelDataAsync(string username);
        Task<EditProfileViewModel> GetDataForEditProfileUserAsync(string username);
        Task<bool> EditProfileAsync(string userName, EditProfileViewModel profile);
        bool CompareOldPassword(string oldPassword, string userName);
        void ChangeUserPassword(string userName, string newPassword);

        #endregion

        #region Wallet

        int BalanceUserWallet(string userName);
        List<WalletViewModel> GetWalletUser(string userName);
        Task<int> ChargeWalletAsync(string userName, int amount, string description, bool isPay = false);
        Task<int> AddWalletAsync(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);

        #endregion

        #region Admin Panel

        UserForAdminViewModel GetUsers(string userName,int pageId = 1, string filterEmail = "", string filterUserName = "");
        UserForAdminViewModel GetDeleteUsers(string userName,int pageId = 1, string filterEmail = "", string filterUserName = "");
        Task<int> AddUserFromAdminAsync(CreateUserViewModel user);
        Task<EditUserViewModel> GetUserForShowInEditModeAsync(int userId);
        Task<int> EditUserFromAdminAsync(EditUserViewModel editUser);

        #endregion

    }
}   
