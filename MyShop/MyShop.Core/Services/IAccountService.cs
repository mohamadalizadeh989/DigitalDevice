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
        Task<bool> RegisterAsync(AccountRegisterVm register);
        Task<bool> LoginAsync(AccountLoginVm login);
        Task<bool> IsDuplicatedUserName(string userName);
        Task<bool> IsDuplicatedEmail(string email);
        Task<bool> IsDuplicatedPassword(string pass);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<User> GetUserByActiveCodeAsync(string activeCode);
        Task<UserDetailVm> GetUserByActiveCodeVm(string activeCode);
        Task<UserDetailVm> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(User user);
        Task<bool> ActiveAccount(string activeCode);
        void UpdateUser(UserDetailVm user);
    }
}
