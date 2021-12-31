using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Base
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
    }

    public class BaseStruct<T> where T : struct
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }
    }
}
