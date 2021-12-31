using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Generator;
using MyShop.Core.Utilities.Extensions;
using MyShop.Core.Utilities.Security;
using MyShop.Core.ViewModels.Users;
using MyShop.Core.ViewModels.Wallet;
using MyShop.DataEf.Contexts;
using MyShop.Domain.Entities.Users;
using MyShop.Domain.Entities.Wallet;
using TopLearn.Core.Security;

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


        #region User

        public async Task<int> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm register)
        {
            try
            {
                var hashPassword = _securityService.HashPassword(register.Password);
                var emailCode = NameGenerator.GenerateUniqCode();
                register.Email = register.Email.Fixed();
                User user = new User
                {
                    UserName = register.UserName,
                    Password = hashPassword,
                    UserAvatar = "Default.jpg",
                    CreateDate = DateTime.Now,
                    Email = register.Email,
                    ActiveCode = emailCode,
                    IsActive = false // Todo : Confirm by sending email (false as a default)
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
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

        public void UpdateUser(UserDetailVm user)
        {
            User dbUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);

            if (dbUser != null)
            {
                dbUser.Password = user.Password;
                _context.Update(dbUser);
            }
            _context.SaveChanges();
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public async Task<bool> IsDuplicatedEmailAsync(string email)
        {
            email = email.Fixed();
            return await _context.Users.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsDuplicatedUserNameAsync(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<UserDetailVm> GetUserByEmailAsync(string email)
        {
            email = email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email);
            return user.ToDetailViewModel();
        }

        public async Task<User> GetUserByActiveCodeAsync(string activeCode)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ActiveCode == activeCode);
            return user;
        }

        public async Task<UserDetailVm> GetUserByActiveCodeVmAsync(string activeCode)
        {
            var user = await GetUserByActiveCodeAsync(activeCode);
            return user.ToDetailViewModel();
        }

        public User GetUserByUserName(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        public UserDetailVm GetUserByUserNameVm(string userName)
        {
            var user = GetUserByUserName(userName);
            return user.ToDetailViewModel();
        }

        public async Task<UserDetailVm> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(c => c.UserId == userId);

            return user.ToDetailViewModel();
        }

        public async Task<bool> ActiveAccountAsync(string activeCode)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion


        #region User Panel

        public InformationUserViewModel GetUserInformation(string username)
        {
            var user = GetUserByUserNameVm(username);

            InformationUserViewModel information = new InformationUserViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                CreateDate = user.CreateDate,
                Wallet = BalanceUserWallet(username),
                WebSite = user.WebSite,
                Mobile = user.Mobile,
                Bio = user.Bio
            };

            return information;
        }

        public async Task<SideBarUserPanelViewModel> GetSideBarUserPanelDataAsync(string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username).Select(u => new SideBarUserPanelViewModel
            {
                ImageName = u.UserAvatar,
                CreateDate = u.CreateDate,
                UserName = u.UserName,
            }).SingleAsync();

            return user;
        }

        public async Task<EditProfileViewModel> GetDataForEditProfileUserAsync(string username)
        {
            var user = await _context.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel()
            {
                AvatarName = u.UserAvatar,
                UserName = u.UserName,
                Email = u.Email,
                Mobile = u.Mobile,
                WebSite = u.WebSite,
                Bio = u.Bio
            }).SingleAsync();

            return user;
        }

        public async Task<bool> EditProfileAsync(string userName, EditProfileViewModel profile)
        {
            if (profile.UserAvatar != null)
            {
                string imagePath = "";
                if (profile.AvatarName != "Default.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                await using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await profile.UserAvatar.CopyToAsync(stream);
                }
            }

            var user = GetUserByUserName(userName);
            user.UserName = profile.UserName;
            user.Email = profile.Email;
            user.UserAvatar = profile.AvatarName;
            user.Mobile = profile.Mobile;
            user.Bio = profile.Bio;
            user.WebSite = profile.WebSite;

            UpdateUser(user.ToDetailViewModel());

            return true;
        }

        public bool CompareOldPassword(string password, string userName)
        {
            var user = _context.Users.SingleOrDefault(c => c.UserName == userName);
            var verifyPass = _securityService.VerifyHashedPassword(user.Password, password);

            if (verifyPass != true)
                return false;

            var userPass = _context.Users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
            return userPass;
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            var user = GetUserByUserNameVm(userName);
            user.Password = _securityService.HashPassword(newPassword);
            UpdateUser(user);
        }

        #endregion


        #region Wallet

        public int BalanceUserWallet(string userName)
        {
            int userId = GetUserIdByUserName(userName);
            var deposit = _context.Wallets
                .Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount).ToList();

            var withdrawal = _context.Wallets
                .Where(w => w.UserId == userId && w.TypeId == 2)
                .Select(w => w.Amount).ToList();

            return (deposit.Sum() - withdrawal.Sum());
        }

        public List<WalletViewModel> GetWalletUser(string userName)
        {
            int userId = GetUserIdByUserName(userName);
            var walletUser = _context.Wallets
                .Where(w => w.IsPay && w.UserId == userId)
                .Select(w => new WalletViewModel
                {
                    Amount = w.Amount,
                    DateTime = w.CreateDate,
                    Description = w.Description,
                    Type = w.TypeId
                })
                .ToList();
            return walletUser;
        }

        public async Task<int> ChargeWalletAsync(string userName, int amount, string description, bool isPay = false)
        {
            Wallet wallet = new Wallet
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                IsPay = isPay,
                UserId = GetUserIdByUserName(userName),
                TypeId = 1,
                Description = description
            };
            return await AddWalletAsync(wallet);
        }

        public async Task<int> AddWalletAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _context.Wallets.Find(walletId);
        }

        public void UpdateWallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }

        #endregion
    }
}
