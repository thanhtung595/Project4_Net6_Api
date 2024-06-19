using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class Cart : BaseEntity
    {
        public int count { get; set; }
        public float priceTotal { get; set; }
        public int idAccount { get; set; }
        public int idProduct { get; set; }

        [ForeignKey("idAccount")]
        public virtual Account? Account { get; set; }

        [ForeignKey("idProduct")]
        public virtual Product? Product { get; set; }
    }
}
