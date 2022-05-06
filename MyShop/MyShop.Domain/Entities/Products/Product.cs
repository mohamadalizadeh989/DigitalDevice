using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;

namespace MyShop.Domain.Entities.Products
{
    public class Product : IAuditable
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ProductTitle { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductPrice { get; set; }

        public int Discount { get; set; }

        [Display(Name = "شرح محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ProductImageName { get; set; }

        [MaxLength(100)]
        public string DemoFileName { get; set; }

        public bool IsDelete { get; set; }



        #region Auditable

        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion


        #region Relations

        [ForeignKey("GroupId")]
        public ProductGroup ProductGroupss { get; set; }

        [ForeignKey("SubGroup")]
        public ProductGroup Groupss { get; set; }

        public ProductStatus ProductStatus { get; set; }

        public ProductLevel ProductLevel { get; set; }

        public List<ProductComment> ProductComments { get; set; }

        #endregion
    }
}
