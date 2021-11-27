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
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        public Guid EmailCode { get; set; }
        public bool EmailConfirm { get; set; }

        [Required, MaxLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(150)]
        //[RegularExpression("(\\+98|0)?9\\d{9}")]
        public string Mobile { get; set; }
        public bool IsActive { get; set; }


        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        #endregion
    }
}
