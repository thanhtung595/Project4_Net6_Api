using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class ListProductBill : BaseEntity
    {
        public float priceTotal { get; set; }
        public int idBill { get; set; }
        public int idProduct { get; set; }

        [ForeignKey("idBill")]
        public virtual Bill? Bill { get; set; }

        [ForeignKey("idProduct")]
        public virtual Product? Product { get; set; }
    }
}
