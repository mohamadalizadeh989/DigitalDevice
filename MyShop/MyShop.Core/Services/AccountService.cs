using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Generator;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;
using MyShop.DataEf.Contexts;
using MyShop.Domain.Entities.Users;

namespace MyShop.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly MyShopContext _context;
        private readonly ISecurityService _securityService;

        public AccountService(MyShopContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<UserDetailVm> GetUserByEmailAsync(string email)
        {
            email = email.Fixed();
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Email == email);

            return user.ToDetailViewModel();
        }

        public async Task<UserDetailVm> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Id == userId);
            return user.ToDetailViewModel();
        }

        public async Task<int> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            email = email.Fixed();
            return await _context.Users.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsDuplicatedUserName(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm register)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(register.Password);
                var emailCode = NameGenerator.GenerateUniqCode();
                register.Email = register.Email.Fixed();
                User user = new User
                {
                    UserName = register.UserName,
                    Password = hassPassword,
                    UserAvatar = "Default.jpg",
                    CreateDate = DateTime.Now,
                    Email = register.Email,
                    ActiveCode = emailCode,
                    EmailConfirm = true, // Todo : Confirm by sending email (false as a default)
                    IsActive = false,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }

        public async Task<bool> LoginAsync(AccountLoginVm login)
        {
            var email = login.Email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email);

            if (user != null)
            {
                var verifyPass = _securityService.VerifyHashedPassword(user.Password, login.Password);
                return verifyPass;
            }
            return false;
        }

        public async Task<bool> ActiveAccount(string activeCode)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
