using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels.Users
{
    public class InformationUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public int Wallet { get; set; }
    }

    public class SideBarUserPanelViewModel
    {
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string Skill { get; set; }
    }
}
