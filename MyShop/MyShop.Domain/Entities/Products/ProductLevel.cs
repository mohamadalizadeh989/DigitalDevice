using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;

namespace MyShop.Domain.Entities.Products
{
    public class ProductLevel
    {
        [Key]
        public int LevelId { get; set; }

        [MaxLength(150)]
        [Required]
        public string LevelTitle { get; set; }


        #region Relation

        public List<Product> Products { get; set; }

        #endregion
    }
}
