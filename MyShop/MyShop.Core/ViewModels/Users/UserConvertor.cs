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
                UserName = user.UserName,
                Id = user.UserId,
                IsActive = user.IsActive,
                Mobile = user.Mobile,
                Skill = user.Skill,
                Bio = user.Bio,
                WebSite = user.WebSite
            };
        }
        public static IQueryable<UserDetailVm> ToDetailViewModel(this IQueryable<User> users)
        {
            return users.Select(user => user.ToDetailViewModel());
        }
    }
}
