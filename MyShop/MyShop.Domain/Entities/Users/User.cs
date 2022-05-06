using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;
using MyShop.Domain.Entities.Orders;
using MyShop.Domain.Entities.Products;

namespace MyShop.Domain.Entities.Users
{
    public class User: IAuditable
    {
        public User()
        {

        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Required, MaxLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(150)]
        //[RegularExpression("(\\+98|0)?9\\d{9}")]
        public string Mobile { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }

        [Display(Name = "مهارت")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Skill { get; set; }

        [Display(Name = "بیوگرافی")]
        [MaxLength(int.MaxValue, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Bio { get; set; }

        [Display(Name = "وب سایت")]
        [MaxLength(int.MaxValue, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string WebSite { get; set; }

        public bool IsDelete { get; set; }



        #region Auditable

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations

        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Wallet.Wallet> Wallets { get; set; }

        #endregion

    }
}
