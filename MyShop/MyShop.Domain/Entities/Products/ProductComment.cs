﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;
using MyShop.Domain.Entities.Users;

namespace MyShop.Domain.Entities.Products
{
    public class ProductComment : IAuditable
    {
        [Key]
        public long CommentId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
        public byte Rate { get; set; }


        #region Auditable

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

        #endregion

        #region Relations

        public Product Product { get; set; }
        public User User { get; set; }

        #endregion
    }
}
