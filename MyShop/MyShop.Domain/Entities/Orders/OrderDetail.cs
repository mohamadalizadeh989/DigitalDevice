using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;
using MyShop.Domain.Entities.Products;

namespace MyShop.Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity<long>
    {
        public long ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }



        #region Relations

        public Product Product { get; set; }
        public Order Order { get; set; }

        #endregion
    }
}
