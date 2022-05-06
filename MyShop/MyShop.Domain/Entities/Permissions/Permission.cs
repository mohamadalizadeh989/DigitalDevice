using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entities.Permissions
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string PermissionTitle { get; set; }
        public int? ParentID { get; set; }


        #region Relation

        [ForeignKey("ParentID")]
        public List<Permission> Permissions { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        #endregion

    }
}
