using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyShop.Domain.Entities.Wallet
{
    public class WalletType
    {
        public WalletType()
        {
            
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }


        [Required]
        [MaxLength(150)]
        public string TypeTitle { get; set; }


        #region Relation

        public virtual ICollection<Wallet> Wallets { get; set; }

        #endregion
    }
}
