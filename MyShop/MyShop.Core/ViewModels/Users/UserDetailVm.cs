using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels.Users
{
    public class UserDetailVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid ActiveCode { get; set; }
        public bool EmailConfirm { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}