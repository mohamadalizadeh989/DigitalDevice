using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Domain.Base;
using MyShop.Domain.Entities.Users;

namespace MyShop.Domain.Entities.Orders
{
    public class Order : BaseEntity<long>
    {
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public bool IsFinalized { get; set; }


        #region Relations

        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
