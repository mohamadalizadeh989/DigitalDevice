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
    public class ProductGroup : BaseEntity<int>, IAuditable
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }


        #region Auditable

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations

        [ForeignKey("GroupId")]
        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
