            using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels.Users
{
    public class AccountRegisterVm
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "{0} شما صحیح نمی باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "{0} را صحیح وارد کنید")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }

    public class AccountLoginVm
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "{0} شما صحیح نمی باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool IsRemember { get; set; }
    }
}
