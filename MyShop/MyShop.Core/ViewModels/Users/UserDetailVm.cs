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
        public string Password { get; set; }
        public string ActiveCode { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string Skill { get; set; }
        public string Bio { get; set; }
        public string WebSite { get; set; }
    }
}