using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Entities.Users;

namespace MyShop.Core.ViewModels.Users
{
    public static class UserConvertor
    {
        public static UserDetailVm ToDetailViewModel(this User user)
        {
            return new UserDetailVm
            {
                Email = user.Email,
                Password = user.Password,
                CreateDate = user.CreateDate,
                ActiveCode = user.ActiveCode,
                EmailConfirm = user.EmailConfirm,
                UserName = user.UserName,
                Id = user.Id,
                IsActive = user.IsActive,
                Mobile = user.Mobile
            };
        }
        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }
    }
}
