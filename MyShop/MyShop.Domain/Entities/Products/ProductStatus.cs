using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;

namespace MyShop.Domain.Entities.Products
{
    public class ProductStatus
    {
        [Key] 
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }

        #region Relation

        public List<Product> Products { get; set; }

        #endregion
    }
}
