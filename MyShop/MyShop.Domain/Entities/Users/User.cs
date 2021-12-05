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
    public class User : BaseEntity<int>, IAuditable
    {
        public User()
        {

        }


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

        public bool EmailConfirm { get; set; }

        [Required, MaxLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(150)]
        //[RegularExpression("(\\+98|0)?9\\d{9}")]
        public string Mobile { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }


        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        #endregion
    }
}
