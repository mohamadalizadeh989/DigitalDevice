using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.ViewModels.Users;
using MyShop.DataEf.Contexts;
using MyShop.Domain.Entities.Users;
using Shop.Core.Utilities.Security;

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

        public async Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm)
        {
            var email = vm.Email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email);

            if (user != null)
            {
                return _securityService.VerifyHashedPassword(user.Password, vm.Password);
            }
            return false;
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

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            email = email.Fixed();
            var user= await _context.Users.AnyAsync(c => c.Email == email);
            return user;
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var emailCode = Guid.NewGuid();
                vm.Email = vm.Email.Fixed();
                await _context.Users.AddAsync(new User
                {
                    Password = hassPassword,
                    CreateDate = DateTime.Now,
                    Email = vm.Email,
                    EmailCode = emailCode,
                    EmailConfirm = true, // Todo : Confirm by sending email (false as a default)
                    IsActive = true,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }
    }
}
