using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;

namespace MyShop.Domain.Entities.Products
{
    public class ProductGroup : IAuditable
    {
        [Key] 
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }

        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        #region Auditable

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations

        //[ForeignKey("GroupId")]

        [ForeignKey("ParentId")]
        public List<ProductGroup> ProductGroups { get; set; }

        [InverseProperty("ProductGroupss")]
        public List<Product> Products { get; set; }

        [InverseProperty("Groupss")]
        public List<Product> SubGroup { get; set; }


        #endregion
    }
}
 