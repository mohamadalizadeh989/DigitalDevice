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
    public class Product : BaseEntity<long>, IAuditable
    {
        public int GroupId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }



        #region Auditable

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations

        public ProductGroup ProductGroup { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        
        #endregion
    }
}
