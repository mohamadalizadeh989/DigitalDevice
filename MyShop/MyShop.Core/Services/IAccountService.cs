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
        Task<bool> RegisterAsync(AccountRegisterVm register);
        Task<bool> LoginAsync(AccountLoginVm login);
        Task<bool> IsDuplicatedEmailAsync(string email);
        Task<bool> IsDuplicatedUserNameAsync(string userName);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<User> GetUserByActiveCodeAsync(string activeCode);
        Task<UserDetailVm> GetUserByActiveCodeVmAsync(string activeCode);
        User GetUserByUserName(string userName);
        UserDetailVm GetUserByUserNameVm(string userName);
        Task<UserDetailVm> GetUserByIdAsync(int userId);
        Task<bool> ActiveAccountAsync(string activeCode);
        void UpdateUser(UserDetailVm user);
        int GetUserIdByUserName(string userName);

        #endregion

        #region User Panel

        InformationUserViewModel GetUserInformation(string username);
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
    }
}
