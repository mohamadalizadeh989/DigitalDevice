﻿using System;
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
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<UserDetailVm> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(User user);
        Task<bool> ActiveAccount(string activeCode);
    }
}
